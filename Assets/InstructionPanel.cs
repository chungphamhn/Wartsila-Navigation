using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanel : MonoBehaviour {

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Instruction;

    public void OnClick() {
        MainMenu.SetActive(false);
        //Instruction.SetActive(true);

        if(GameObject.Find("InstructionsPanel") == null) {
            Instruction.SetActive(true);
        }
        else {
            Instruction.SetActive(false);
        }
    }
}
