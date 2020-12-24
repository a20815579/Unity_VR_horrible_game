using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallCtrl : TouchedControllerVR
{
    [SerializeField]
    Vector3 OnGrabRotation = new Vector3(135.6f, 153.8f, 148.6f);
    [SerializeField]
    Transform ballObj;
    public void OnGrab()
    {
        ballObj.localEulerAngles = OnGrabRotation;
        Invoke("TurnAround", 5f);
    }

    void TurnAround()
    {
        ballObj.GetComponent<Animator>().enabled = true;
        Debug.Log("here");
        base.ResponseOnInput();
    }
    
}
