using System.Collections;
using System.Reflection;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip incorrectClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f; // 3D
    }

    private void Play(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(clip, Random.Range(0.8f, 1.0f));
        }
    }

    public void PlayCorrectClip()
    {
        Play(correctClip);
    }

    public void PlayInorrectClip()
    {
        Play(incorrectClip);
    }
}
