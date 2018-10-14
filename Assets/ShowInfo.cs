using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShowInfo : VRTK_InteractableObject
{

    //float spinSpeed = 0f;
    //Transform rotator;
    public GameObject UI;



    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        //spinSpeed = 360f;
        UI.SetActive(true);
    }

    public override void StopUsing(VRTK_InteractUse usingObject)
    {
        base.StopUsing(usingObject);
        //spinSpeed = 0f;
        UI.SetActive(false);
    }

    protected void Start()
    {
        //rotator = transform.Find("Capsule");
    }

    protected override void Update()
    {
        base.Update();
        //rotator.transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0f, 0f));
    }


}
