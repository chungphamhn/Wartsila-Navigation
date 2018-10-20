using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject valve;
    private Rigidbody door;
    public float rotation;


	// Use this for initialization
	void Start () {

        door = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(valve.transform.localRotation.eulerAngles.x >= 100);

        if(valve.transform.localRotation.eulerAngles.x >= 100)
        {

            //can open door
            door.isKinematic = false;
            
        }
		
	}
}
