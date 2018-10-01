using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class Interactable : MonoBehaviour
{
    private VRTK_InteractableObject interactableObject;
    private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip grabbedAudioClip;
    [SerializeField] private AudioClip ungrabbedAudioClip;
    private AudioSource audioSource;
    [SerializeField] private bool debugging = false;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
	audioSource.spatialBlend = 1.0f; // 3D
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectGrabbed += OnGrabbed;
        interactableObject.InteractableObjectUngrabbed += OnUngrabbed;
    }

    private void AudioTest()
    {
        if (controllerReference != null)
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, grabbedAudioClip);
        }
        if (audioSource != null)
        {
            audioSource.clip = grabbedAudioClip;
            audioSource.Play();
        }
    }

    private void OnGrabbed (object sender, InteractableObjectEventArgs e)
    {
        if (debugging)
        {
            Debug.Log("grabbed");
        }
        controllerReference = VRTK_ControllerReference.GetControllerReference(e.interactingObject);
        InvokeRepeating("AudioTest", 0f, 2f);
    }
        
    private void OnUngrabbed (object sender, InteractableObjectEventArgs e)
    {
        if (debugging)
        {
            Debug.Log("ungrabbed");
        }
        CancelInvoke("AudioTest");
        if (audioSource != null)
        {
            audioSource.clip = ungrabbedAudioClip;
            audioSource.Play();
        }
        controllerReference = null;
    }
}
