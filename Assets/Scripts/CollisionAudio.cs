using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableAudioObject))]
public class CollisionAudio : MonoBehaviour {

    [System.Serializable]
    struct TaggedCollisionArray {
        public string tag;
        public AudioClip[] collisionClips;
    }

    private AudioSource interactableAudioSource;
    private AudioSource collisionAudioSource;
    [SerializeField] TaggedCollisionArray[] taggedCollisionClips;

    AudioClip GetCollisionClip(string tag)
    {
        // if tag does not exist, default to first set of clips
        int tagNumber = 0;
        int i = 0;
        while (i < taggedCollisionClips.Length)
        {
            if (taggedCollisionClips[i].tag == tag)
                tagNumber = i;
            i++;
        }
        
        int n = Random.Range(1, taggedCollisionClips[tagNumber].collisionClips.Length);

        // move picked sound to index 0 so it's not picked next time
        AudioClip temp = taggedCollisionClips[tagNumber].collisionClips[n];
        taggedCollisionClips[tagNumber].collisionClips[n] = taggedCollisionClips[tagNumber].collisionClips[0];
        taggedCollisionClips[tagNumber].collisionClips[0] = temp;

        return temp;
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.relativeVelocity.magnitude > 2)
	PlayCollisionClip(collision.gameObject.tag);
    }

    // plays a random collisionClip at a random volume
    void PlayCollisionClip(string tag)
    {
        AudioClip randomCollisionClip = GetCollisionClip(tag);
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
