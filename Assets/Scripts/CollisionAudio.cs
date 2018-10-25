using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableAudioObject))]
public class CollisionAudio : MonoBehaviour {

    private AudioSource interactableAudioSource;
    private AudioSource collisionAudioSource;
    [SerializeField] AudioClip[] collisionClips;

    AudioClip GetCollisionClip()
    {
        int n = Random.Range(1, collisionClips.Length);

        // move picked sound to index 0 so it's not picked next time
        AudioClip temp = collisionClips[n];
        collisionClips[n] = collisionClips[0];
        collisionClips[0] = temp;

        return temp;
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.relativeVelocity.magnitude > 2)
            PlayCollisionClip();
    }

    // plays a random collisionClip at a random volume
    void PlayCollisionClip()
    {
        AudioClip randomCollisionClip = GetCollisionClip();
        float randomVolume = Random.Range(0.7f, 1.0f);

        if(randomCollisionClip)
        {
            collisionAudioSource.PlayOneShot(randomCollisionClip, randomVolume);
        }
    }

    void Start ()
    {
        // for copying the field values of the main audio source
        interactableAudioSource = GetComponent<InteractableAudioObject>().GetInteractableAudioSource();

        // audio source for collisions  
        collisionAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        System.Reflection.FieldInfo[] fields = typeof(AudioSource).GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(collisionAudioSource, field.GetValue(interactableAudioSource));
        }
    }
}
