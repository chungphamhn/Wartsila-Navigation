using System.Collections;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InstructionPanelAudio : MonoBehaviour
{
    //private VRTK_InteractableObject interactableObject;
    //private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip newPageClip;
    [SerializeField] private AudioClip panelOffClip;
    private AudioSource audioSource;

    private void OnDisable()
    {
        if (panelOffClip != null)
        {
	    // temporary audio source for playing clip when disabling panel
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
	    tempAudioSource.PlayOneShot(panelOffClip, Random.Range(0.8f, 1.0f));

	    Destroy(tempObject, 3f);
	}
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
        Play(newPageClip);
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
