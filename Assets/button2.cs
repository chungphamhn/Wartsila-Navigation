using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using VRTK;

[RequireComponent(typeof(ButtonAudio))]
public class button2 : MonoBehaviour {

    public Button btn;

    public bool click;

    // Use this for initialization
    void Start () {
        //btn = gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
	ButtonAudio btnAudio = btn.GetComponent<ButtonAudio>();
        click = true;
        Debug.Log(OilLeakCheck.leaks[1]);
        if (OilLeakCheck.leaks[1])
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
