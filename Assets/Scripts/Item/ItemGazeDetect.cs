using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGazeDetect : MonoBehaviour, iGazeReceiver
{
    private bool _isGazingUpon;

    public bool IsGazingUpon { get => _isGazingUpon; set => _isGazingUpon = value; }

    public void GazingUpon()
    {
        //Debug.Log("G");
        _isGazingUpon = true;
    }

    public void NotGazingUpon()
    {
        //Debug.Log("N");

        _isGazingUpon = false;
    }
}
