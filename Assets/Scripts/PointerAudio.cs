using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class PointerAudio : MonoBehaviour
{
    private VRTK_Pointer pointer;
    private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip activationButtonPressedClip;
    [SerializeField] private AudioClip activationButtonReleasedClip;
    [SerializeField] private AudioClip selectionButtonPressedClip;
    [SerializeField] private AudioClip selectionButtonReleasedClip;
    [SerializeField] private AudioClip pointerStateValidClip;
    [SerializeField] private AudioClip pointerStateInvalidClip;
    private AudioSource audioSource;
    [SerializeField] private bool debugging = false;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
        pointer = GetComponent<VRTK_Pointer>();
        pointer.ActivationButtonPressed += OnIAOActivationButtonPressed;
        pointer.ActivationButtonReleased += OnIAOActivationButtonReleased;
        pointer.SelectionButtonPressed += OnIAOSelectionButtonPressed;
        pointer.SelectionButtonReleased += OnIAOSelectionButtonReleased;
        pointer.PointerStateValid += OnIAOPointerStateValid;
        pointer.PointerStateInvalid += OnIAOPointerStateInvalid;
    }

    private void Play(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void OnIAOActivationButtonPressed (object sender, ControllerInteractionEventArgs e)
    {
        Play(activationButtonPressedClip);
    }

    private void OnIAOActivationButtonReleased (object sender, ControllerInteractionEventArgs e)
    {
        Play(activationButtonReleasedClip);
    }

    private void OnIAOSelectionButtonPressed (object sender, ControllerInteractionEventArgs e)
    {
        Play(selectionButtonPressedClip);
    }

    private void OnIAOSelectionButtonReleased (object sender, ControllerInteractionEventArgs e)
    {
        Play(selectionButtonReleasedClip);
    }

    private void OnIAOPointerStateValid (object sender, DestinationMarkerEventArgs e)
    {
        Play(pointerStateValidClip);
    }

    private void OnIAOPointerStateInvalid (object sender, DestinationMarkerEventArgs e)
    {
        Play(pointerStateInvalidClip);
    }

}
