using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLeakCheck : MonoBehaviour {

    public GameObject[] oilLeaks;
    public static bool[] leaks = new bool[4];
    private int rnd;
    public static bool initializing = true; // for not starting leak audio until done randomizing

    // Use this for initialization
    void Start () {

        rnd = Random.Range(0,4);
        Debug.Log(rnd);

        for (int i = 0; i < rnd; i++)
        {
            oilLeaks[i].SetActive(true);
            Debug.Log(oilLeaks);
            leaks[i] = true;
            Debug.Log(leaks);
        }
	initializing = false;
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
