using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Word_1_3_Ctrl : MonoBehaviour
{
    
    public GameObject wordImg;
    
    public void Appear()
    {
        Debug.Log("Word Appear");
        wordImg.GetComponent<Animation>().Play("FadeIn");
        
    }
    
}
