﻿using System.Collections;
using System.Reflection;
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
    private AudioSource interactableAudioSource;
    private AudioSource turningAudioSource;
    private Quaternion previousRotation;
    [SerializeField] private AudioClip turningClip; // should be a loop
    [SerializeField] private bool turnable = false;
    [SerializeField] private bool debugging = false;

    private void Awake()
    {
        interactableAudioSource = GetComponent<AudioSource>();
        interactableAudioSource.spatialBlend = 1.0f; // 3D
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

        if (turnable)
        {
            // another audio source for looping turning audio for valves
            turningAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
	    BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
	    System.Reflection.PropertyInfo[] properties = typeof(AudioSource).GetProperties(flags);
	    foreach (System.Reflection.PropertyInfo property in properties)
	    {
		if (property.CanWrite) {
		    try
		    {
			property.SetValue(turningAudioSource, property.GetValue(interactableAudioSource, null), null);
		    }
		    catch { }
		}
	    }
	    System.Reflection.FieldInfo[] fields = typeof(AudioSource).GetFields(flags);
	    foreach (System.Reflection.FieldInfo field in fields)
	    {
		field.SetValue(turningAudioSource, field.GetValue(interactableAudioSource));
	    }   
            turningAudioSource.clip = turningClip;
            turningAudioSource.volume = 0f;
            turningAudioSource.loop = true;
            turningAudioSource.Play();

            // for keeping track of rotation changes
            previousRotation = transform.rotation;
        }
    }

    private IEnumerator _GetInteractableAudioSource ()
    {
        while ( interactableAudioSource == null)
        {
            yield return null;
        }
    }

    public AudioSource GetInteractableAudioSource()
    {
        //StartCoroutine(_GetInteractableAudioSource());
        return interactableAudioSource;
    }

    private void OnIAOEnteredSnapDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(enteredSnapDropZoneClip);
    }

    private void OnIAOExitedSnapDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(exitedSnapDropZoneClip);
    }

    private void OnIAOGrabbed (object sender, InteractableObjectEventArgs e)
    {
        controllerReference = VRTK_ControllerReference.GetControllerReference(e.interactingObject);
        Play(grabbedClip);
    }
        
    private void OnIAOSnappedToDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(snappedToDropZoneClip);
    }

    private void OnIAOTouched (object sender, InteractableObjectEventArgs e)
    {
        Play(touchedClip);
    }

    private void OnIAOUngrabbed (object sender, InteractableObjectEventArgs e)
    {
        Play(ungrabbedClip);
        controllerReference = null;
    }

    private void OnIAOUnsnappedFromDropZone (object sender, InteractableObjectEventArgs e)
    {
        Play(unsnappedFromDropZoneClip);
    }

    private void OnIAOUntouched (object sender, InteractableObjectEventArgs e)
    {
        Play(untouchedClip);
    }

    private void OnIAOUnused (object sender, InteractableObjectEventArgs e)
    {
        Play(unusedClip);
    }

    private void OnIAOUsed (object sender, InteractableObjectEventArgs e)
    {
        Play(usedClip);
    }

    private void Play(AudioClip clip)
    {
        if (interactableAudioSource != null)
        {
            //interactableAudioSource.clip = clip;
            interactableAudioSource.pitch = Random.Range(0.9f, 1.1f);
            interactableAudioSource.PlayOneShot(clip, Random.Range(0.8f, 1.0f));
        }
    }

    public void SetTurningAudioActive(bool active = true)
    {
        turnable = active; 
        if (!turnable)
        {
            turningAudioSource.Stop();
            turningAudioSource.volume = 0f;
        }
    }
    
    private void Update()
    {
        // fade in turning clip if object (e.g. valve handle) is being turned
        if (turnable)
        {
            Quaternion currentRotation = transform.rotation;
            float rotationDelta = Quaternion.Angle(previousRotation, currentRotation);
            if (rotationDelta > 0.01f)
            {
                previousRotation = currentRotation;
                if (turningAudioSource.volume < 1f)
                {
                    turningAudioSource.volume += Time.deltaTime * rotationDelta;
                }
            }
            else
            {
                if (turningAudioSource.volume > 0f)
                {
                    turningAudioSource.volume -= Time.deltaTime * 5f;
                }
            }
        }           
    }
}
