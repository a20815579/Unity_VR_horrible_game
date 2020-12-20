using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGazeDetect : MonoBehaviour, iGazeReceiver
{
    private bool _isGazingUpon;

    public bool IsGazingUpon { get => _isGazingUpon; set => _isGazingUpon = value; }

    public void GazingUpon()
    {
            
        IsGazingUpon = true;
    }

    public void NotGazingUpon()
    {
        IsGazingUpon = false;
    }
}
