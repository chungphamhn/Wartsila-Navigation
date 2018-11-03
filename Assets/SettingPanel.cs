using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject settingPanel;
	// Use this for initialization

    public void OnClick() {
        MainMenu.SetActive(false);
        settingPanel.SetActive(true);
    }
}
