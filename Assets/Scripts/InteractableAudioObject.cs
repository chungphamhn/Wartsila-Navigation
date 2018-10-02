using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class InteractableAudioObject : MonoBehaviour
{
    private VRTK_InteractableObject interactableObject;
    private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip touchedClip;
    [SerializeField] private AudioClip untouchedClip;
    [SerializeField] private AudioClip grabbedClip;
    [SerializeField] private AudioClip ungrabbedClip;
    [SerializeField] private AudioClip usedClip;
    [SerializeField] private AudioClip unusedClip;
    [SerializeField] private AudioClip enteredSnapDropZoneClip;
    [SerializeField] private AudioClip exitedSnapDropZoneClip;
    [SerializeField] private AudioClip snappedToDropZoneClip;
    [SerializeField] private AudioClip unsnappedFromDropZoneClip;
    private AudioSource audioSource;
    [SerializeField] private bool debugging = false;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectTouched += OnIAOTouched;
        interactableObject.InteractableObjectUntouched += OnIAOUntouched;
        interactableObject.InteractableObjectGrabbed += OnIAOGrabbed;
        interactableObject.InteractableObjectUngrabbed += OnIAOUngrabbed;
        interactableObject.InteractableObjectUsed += OnIAOUsed;
        interactableObject.InteractableObjectUnused += OnIAOUnused;
        interactableObject.InteractableObjectEnteredSnapDropZone += OnIAOEnteredSnapDropZone;
        interactableObject.InteractableObjectExitedSnapDropZone += OnIAOExitedSnapDropZone;
        interactableObject.InteractableObjectSnappedToDropZone += OnIAOSnappedToDropZone;
        interactableObject.InteractableObjectUnsnappedFromDropZone += OnIAOUnsnappedFromDropZone;
    }

    private void Play(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void OnIAOTouched (object sender, InteractableObjectEventArgs e)
    {
        Play(touchedClip);
    }

    private void OnIAOUntouched (object sender, InteractableObjectEventArgs e)
    {
        Play(untouchedClip);
    }

    private void OnIAOGrabbed (object sender, InteractableObjectEventArgs e)
    {
        controllerReference = VRTK_ControllerReference.GetControllerReference(e.interactingObject);
        Play(grabbedClip);
    }
        
    private void OnIAOUngrabbed (object sender, InteractableObjectEventArgs e)
    {
        Play(ungrabbedClip);
        controllerReference = null;
    }

    private void OnIAOUsed (object sender, InteractableObjectEventArgs e)
    {
        Play(usedClip);
    }

    private void OnIAOUnused (object sender, InteractableObjectEventArgs e)
    {
        Play(unusedClip);
    }

    private void OnIAOEnteredSnapDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(enteredSnapDropZoneClip);
    }

    private void OnIAOExitedSnapDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(exitedSnapDropZoneClip);
    }

    private void OnIAOSnappedToDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(snappedToDropZoneClip);
    }

    private void OnIAOUnsnappedFromDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(unsnappedFromDropZoneClip);
    }
}
