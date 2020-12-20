using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WordCtrl : MonoBehaviour, iGazeReceiver
{
    private bool isGazingUpon;
    //public event Action OnAppearEndEvent;
    private void Update()
    {
        if (isGazingUpon)
        {
            Debug.Log("gaze");
        }
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }

    //public void OnAppearEnd()
    //{
    //    OnAppearEndEvent?.Invoke();
    //}

    public void Disappear()
    {
        GetComponent<Animation>().Play("FadeOut");
    }

    public void GazingUpon()
{
  isGazingUpon = true;
}

public void NotGazingUpon()
{
  isGazingUpon = false;
}
}
