using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float timer;
    public Text clock;
    private bool timerStarted;
    private 

	// Use this for initialization
	void Start () {
        timer = 0.0f;
        timerStarted = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timerStarted)
        {
            timer += Time.deltaTime;
        }

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        clock.text = minutes + ":" + seconds;
    }

    public void OnTriggerEnter(Collider other)
    {
        timerStarted = true;   
    }
}
