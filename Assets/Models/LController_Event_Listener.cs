using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LController_Event_Listener : MonoBehaviour {

    public GameObject mainMenuCanvas;

    private void Start()
    {
        if (GetComponent<VRTK_ControllerEvents>() == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }
        GetComponent<VRTK_ControllerEvents>().TouchpadPressed += LController_Event_Listener_TouchpadPressed;
    }

    private void LController_Event_Listener_TouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        mainMenuCanvas.SetActive(!mainMenuCanvas.activeSelf);
        mainMenuCanvas.transform.GetChild(0).gameObject.SetActive(true);
        for(int i = 1; i < mainMenuCanvas.transform.childCount; i++) {
            mainMenuCanvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        
    }
}
