using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGasValve : MonoBehaviour {

    public GameObject valve;
    public static bool valveOpened;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(valveOpened);
        Debug.Log(valve.transform.localRotation.eulerAngles.z);
        Debug.Log(valve.transform.rotation.eulerAngles.z);

        if (valve.transform.localRotation.eulerAngles.z >= 267)
        {

            // lock valve and prevent further valve rotation audio
            valve.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
            //valve.GetComponent<InteractableAudioObject>().SetTurningAudioActive(false);
            valveOpened = true;
        }

    }
}
