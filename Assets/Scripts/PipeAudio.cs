using System.Collections;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PipeAudio : MonoBehaviour {

    [SerializeField] private int pipe;
    [SerializeField] private AudioClip leakClip; // should be a loop
    [SerializeField] private AudioClip normalClip; // should be a loop
    private AudioSource audioSource;
    private AudioSource leakAudioSource;

    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
	audioSource.clip = normalClip;	
	audioSource.loop = true;
	audioSource.Play();
	StartCoroutine(WaitForOilLeakCheck());
    }

    IEnumerator WaitForOilLeakCheck()
    {
	while(OilLeakCheck.initializing)
	    yield return new WaitForSeconds(.1f);
	StartLeakAudio();
    }

    void StartLeakAudio()
    {
	if(OilLeakCheck.leaks[pipe-1])
	{
            // another audio source for looping leak audio for valves
            leakAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
	    BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
	    System.Reflection.PropertyInfo[] properties = typeof(AudioSource).GetProperties(flags);
	    foreach (System.Reflection.PropertyInfo property in properties)
	    {
		if (property.CanWrite) {
		    try
		    {
			property.SetValue(leakAudioSource, property.GetValue(audioSource, null), null);
		    }
		    catch { }
		}
	    }
	    System.Reflection.FieldInfo[] fields = typeof(AudioSource).GetFields(flags);
	    foreach (System.Reflection.FieldInfo field in fields)
	    {
		field.SetValue(leakAudioSource, field.GetValue(audioSource));
	    }

	    // move down
	    
            leakAudioSource.clip = leakClip;
            leakAudioSource.loop = true;
            leakAudioSource.Play();
	}
    }
}
