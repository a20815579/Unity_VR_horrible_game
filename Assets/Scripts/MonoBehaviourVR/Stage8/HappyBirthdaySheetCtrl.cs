using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyBirthdaySheetCtrl : MonoBehaviour
{
    Image sheet;
    [SerializeField]
    public AudioSource audio;

    void Start()
    {
        sheet = GetComponent<Image>();
    }
    public void ShowHappyBirthdaySheetAndPlaySong() {
        gameObject.SetActive(true);
        audio.Play();
    }

    public void HideHappyBirthdaySheet() {
        gameObject.SetActive(false);
    }
}
