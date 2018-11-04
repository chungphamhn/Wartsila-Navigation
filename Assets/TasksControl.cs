using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksControl : MonoBehaviour {

    [SerializeField] private GameObject Tasks;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject WorldKeyboard;
    private Color newColor;

	// Use this for initialization

    public void OnClick() {
        Tasks.SetActive(true);
        MainMenu.SetActive(false);
    }
    private void Update() {
        if (OpenDoor.doorOpened) {
            Tasks.transform.Find("OpenDoor").gameObject.GetComponent<Image>().color = Color.green;
            gameObject.transform.Find("OilLeak").gameObject.GetComponent<Button>().interactable = true;
        }

        if(
            WorldKeyboard.GetComponent<button1>().click && WorldKeyboard.GetComponent<button2>().click &&
            WorldKeyboard.GetComponent<button3>().click && WorldKeyboard.GetComponent<button4>().click) {

            Tasks.transform.Find("OilLeak").gameObject.GetComponent<Image>().color = Color.green;
            ColorBlock cb = Tasks.transform.Find("OilLeak").gameObject.GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            Tasks.transform.Find("OilLeak").gameObject.GetComponent<Button>().colors = cb;
        }
    }
}
