using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject valve;
    private Rigidbody door;
    public float rotation;
    public static bool doorOpened;


    // Use this for initialization
    void Start () {

        door = GetComponent<Rigidbody>();
                
    }
        
    // Update is called once per frame
    void Update () {
        
        if(valve.transform.localRotation.eulerAngles.x >= 100)
        {            
            //can open door
            door.isKinematic = false;

            // lock valve and prevent further valve rotation audio
            valve.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            valve.GetComponent<InteractableAudioObject>().SetTurningAudioActive(false);
            doorOpened = true;
        }                
    }
}
