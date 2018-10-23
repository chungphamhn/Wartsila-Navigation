using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class TeleportPointerAudio : MonoBehaviour
{
    private VRTK_Pointer pointer;
    private VRTK_ControllerReference controllerReference;
    [SerializeField] private AudioClip teleportPointerStartClip;
    [SerializeField] private AudioClip teleportPointerLoopClip;
    [SerializeField] private AudioClip teleportCancelClip;
    [SerializeField] private AudioClip teleportGoClip;
    [SerializeField] private AudioClip teleportGoodAreaClip;
    [SerializeField] private AudioClip teleportBadAreaClip;
    private AudioSource audioSource;
    private AudioSource loopingAudioSource;
    [SerializeField] private bool debugging = false;
    private bool validTarget = false;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
        pointer = GetComponent<VRTK_Pointer>();
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
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
    }

    private void OnIAOSelectionButtonPressed (object sender, ControllerInteractionEventArgs e)
    {
        loopingAudioSource.Play();
        Play(teleportPointerStartClip);
    }

    private void OnIAOSelectionButtonReleased (object sender, ControllerInteractionEventArgs e)
    {
        loopingAudioSource.Stop();
        if (validTarget)
            Play(teleportGoClip);
        else
            Play(teleportCancelClip);
    }

    private void OnIAOPointerStateValid (object sender, DestinationMarkerEventArgs e)
    {
        Play(teleportGoodAreaClip);
        validTarget = true;
    }

    private void OnIAOPointerStateInvalid (object sender, DestinationMarkerEventArgs e)
    {
        Play(teleportBadAreaClip);
        validTarget = false;
    }
    
    private void Start()
    {
        loopingAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        System.Reflection.FieldInfo[] fields = typeof(AudioSource).GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(loopingAudioSource, field.GetValue(audioSource));
        }
        loopingAudioSource.clip = teleportPointerLoopClip;
        loopingAudioSource.loop = true;
    }
}
