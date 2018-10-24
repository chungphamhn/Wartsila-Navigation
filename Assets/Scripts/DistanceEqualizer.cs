using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioLowPassFilter))]
[RequireComponent(typeof(AudioSource))]

public class DistanceEqualizer : MonoBehaviour
{
    [SerializeField] bool Cutoff = true;
    [SerializeField] bool VolumeDecrease = true;
    [SerializeField] bool Debugging = false;

    float StartCutoffFrom = 10f;
    [Range(0f, 1f)] float WallCutoff = 0.5f;
    [Range(0.01f, 1f)] float DistanceCutoff = 0.3f; 
    [Range(0f, 1f)] float VolDecPerWall = 0.15f;   
    
    float wallcut;

    AudioListener AudioListener;
    AudioSource AudioSource;

    void Awake ()
    {
        AudioListener = FindObjectOfType<AudioListener>();
        AudioSource = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<AudioLowPassFilter>().enabled = true;
    }

    void Update ()
    {
        float distance = Vector3.Distance(transform.position, AudioListener.transform.position);
        if (distance < AudioSource.maxDistance) 
        {   
            // raycast from AudioSource to AudioListener
            Ray ray = new Ray(transform.position, AudioListener.transform.position - transform.position);
            RaycastHit[] hits = Physics.RaycastAll(ray, distance);

            // volume decrease
            if (VolumeDecrease)
            {
                gameObject.GetComponent<AudioSource>().volume = 1 - VolDecPerWall * hits.Length;
            }

            // lowpass filter cutoff frequency          
            if (Cutoff)
            {
                float distcut = 22000 * Mathf.Pow(0.6f, (distance - StartCutoffFrom) * Mathf.Pow(DistanceCutoff * 10, 3) / 1000);
                float wallcut = Mathf.Atan(hits.Length * (1 + 10 * WallCutoff)) * distcut * WallCutoff;
                gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = distcut - wallcut;
            }
      
            // degub log 
            if (Debugging)
            {
                Debug.Log("Gameobject '" + gameObject.name + "' :: " + "Walls: " + hits.Length +
                          "; current volume: " + gameObject.GetComponent<AudioSource>().volume +
                          "; current cutoff: " + gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency);
                Debug.DrawLine(transform.position, AudioListener.transform.position, Color.green);
            }
        } 
    }
}
