using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using VRTK;

public class button1 : MonoBehaviour {

    public Button btn;

    // Use this for initialization
    void Start () {
        //btn = gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log(OilLeakCheck.leaks[0]);
        if (OilLeakCheck.leaks[0])
        {
            btn.image.color = Color.green;

        } else
        {
            btn.image.color = Color.red;
        }
        
    }
}
