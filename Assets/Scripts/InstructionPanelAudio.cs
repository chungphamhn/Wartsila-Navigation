using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InstructionPanelAudio : MonoBehaviour
{
    //private VRTK_InteractableObject interactableObject;
    //private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip newPageClip;
    private AudioSource audioSource;

    private void Awake()
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
