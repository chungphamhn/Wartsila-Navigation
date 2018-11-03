using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksControl : MonoBehaviour {

    [SerializeField] private GameObject Tasks;
    [SerializeField] private GameObject MainMenu;

	// Use this for initialization

    public void OnClick() {
        Tasks.SetActive(true);
        MainMenu.SetActive(false);
    }
    private void Update() {
        //if(OpenDoor.doorOpened && Tasks.activeSelf) {
        //    GameObject.Find("OilLeak").GetComponent<Button>().enabled = true;
        //    Debug.Log("tasks");
        //}
    }
}
