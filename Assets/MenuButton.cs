using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour {

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Setting;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick() {
        //GetComponent<Image>().color = Color.green;
        Setting.SetActive(true);
        MainMenu.SetActive(false);
        Debug.Log("click");
    }
}
