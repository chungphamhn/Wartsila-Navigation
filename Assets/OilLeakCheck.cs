using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLeakCheck : MonoBehaviour {

    public GameObject[] oilLeaks;
    private int rnd;

    // Use this for initialization
    void Start () {

        rnd = Random.Range(0,4);

        for (int i = 0; i < rnd; i++)
        {
            oilLeaks[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
