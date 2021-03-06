using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class PointerAudio : MonoBehaviour
{
    private VRTK_Pointer pointer;
    private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip activationButtonPressedClip;
    [SerializeField] private AudioClip activationButtonReleasedClip;
    [SerializeField] private AudioClip pointerStateValidClip;
    [SerializeField] private AudioClip pointerStateInvalidClip;
    private AudioSource audioSource;
    [SerializeField] private bool debugging = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
        pointer = GetComponent<VRTK_Pointer>();
        pointer.ActivationButtonPressed += OnIAOActivationButtonPressed;
        pointer.ActivationButtonReleased += OnIAOActivationButtonReleased;
        pointer.PointerStateValid += OnIAOPointerStateValid;
        pointer.PointerStateInvalid += OnIAOPointerStateInvalid;
    }

    private void OnIAOActivationButtonPressed (object sender, ControllerInteractionEventArgs e)
    {
        Play(activationButtonPressedClip);
    }

    private void OnIAOActivationButtonReleased (object sender, ControllerInteractionEventArgs e)
    {
        Play(activationButtonReleasedClip);
    }

    private void OnIAOPointerStateInvalid (object sender, DestinationMarkerEventArgs e)
    {
        Play(pointerStateInvalidClip);
    }

    private void OnIAOPointerStateValid (object sender, DestinationMarkerEventArgs e)
    {
        Play(pointerStateValidClip);
    }

    private void Play(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
    }
}
