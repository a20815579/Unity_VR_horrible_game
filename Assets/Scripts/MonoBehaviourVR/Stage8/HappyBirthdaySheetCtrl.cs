using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyBirthdaySheetCtrl : MonoBehaviour
{
    Image sheet;
    AudioSource audio;

    void Start()
    {
        sheet = GetComponent<Image>();    
        audio = GetComponent<AudioSource>();
    }
    public void ShowHappyBirthdaySheetAndPlaySong() {
        sheet.enabled = true;
        audio.Play();
    }
}
