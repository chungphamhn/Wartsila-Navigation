using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using VRTK;

[RequireComponent(typeof(ButtonAudio))]
public class button4 : MonoBehaviour {

    public Button btn;

    public bool click;


    public void OnClick()
    {
	ButtonAudio btnAudio = btn.GetComponent<ButtonAudio>();
        click = true;
        Debug.Log(OilLeakCheck.leaks[3]);
        if (OilLeakCheck.leaks[3])
        {
            btn.image.color = Color.green;
	    if (btnAudio != null)
		btnAudio.PlayCorrectClip();

        } else
        {
            btn.image.color = Color.red;
	    if (btnAudio != null)
		btnAudio.PlayInorrectClip();
        }
        
    }
}
