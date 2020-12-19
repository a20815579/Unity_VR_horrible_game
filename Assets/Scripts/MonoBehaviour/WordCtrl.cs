using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WordCtrl : MonoBehaviour
{
    //public event Action OnAppearEndEvent;
    public void Appear() {
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
}
