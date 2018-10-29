using System.Collections;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LeftHandMenuAudio : MonoBehaviour {

    [SerializeField] private AudioClip menuOffClip;
    [SerializeField] private AudioClip menuOnClip;
    private AudioSource audioSource;

    private void OnDisable()
    {
        // temporary audio source for playing clip when disabling menu
        GameObject tempObject = new GameObject();
        tempObject.transform.position = transform.position;
        tempObject.transform.rotation = transform.rotation;

        AudioSource tempAudioSource = tempObject.AddComponent(typeof(AudioSource)) as AudioSource;
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        System.Reflection.PropertyInfo[] properties = typeof(AudioSource).GetProperties(flags);
        foreach (System.Reflection.PropertyInfo property in properties)
        {
            if (property.CanWrite) {
                try
                {
                    property.SetValue(tempAudioSource, property.GetValue(audioSource, null), null);
                }
                catch { }
            }
        }
        System.Reflection.FieldInfo[] fields = typeof(AudioSource).GetFields(flags);
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(tempAudioSource, field.GetValue(audioSource));
        }

        tempAudioSource.pitch = Random.Range(0.9f, 1.1f);
        tempAudioSource.PlayOneShot(menuOffClip, Random.Range(0.8f, 1.0f));

        Destroy(tempObject, 3f);
    }
    
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
        Play(menuOnClip);
    }

    private void Play(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(clip, Random.Range(0.8f, 1.0f));
        }
    }
}
