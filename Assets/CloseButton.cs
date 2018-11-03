using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {

    [SerializeField] private GameObject MainMenu;

    public void OnClick() {
        MainMenu.SetActive(false);
    }
}
