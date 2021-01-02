using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage_8_Manager : StageManager
{
    [SerializeField]
    AudioSource[] audios;
    [SerializeField]
    GameObject ball;
    [SerializeField]
    HappyBirthdaySheetCtrl happyBirthdaySheetCtrl;
    [SerializeField]
    GameObject spotLight;

    public override void SetupEvents()
    {
        Debug.Log("Stage 8 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:button down -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene

        // total event: 
        // touch event(): 
        // text event()
        // show image():

        AddEvent(0, ShowImageAndPlaySoundEffect);   
        // 0: button down -> show UI: 彈生日快樂歌給毛球吧

        AddEvent(1, HideImageAndPlaySong);
        // 1: button down -> hide image and play song

        AddEvent(2, WaterPoolIgnite);
        // 2: water pool collides with ball -> water pool ignites

        //StartCoroutine(RunEntireFlow(24));
    }

    IEnumerator Coroutine_21_22_23() {
        for (int i = 22; i < 24; i++) {
            yield return new WaitForSeconds(2.0f);
            ReactOnInput(i);
        }
    }

    IEnumerator RunEntireFlow(int n) {
        for (int i = 0; i < 19; i++) {
            ReactOnInput(i);
        }

        for (int i = 19; i < n; i++) {
            ReactOnInput(i);
            yield return new WaitForSeconds(2.0f);
        }
    }

    void WaterPoolIgnite() {
        spotLight.SetActive(true);
    }

    void HideImageAndPlaySong() {
        HideItemImage();
        happyBirthdaySheetCtrl.ShowHappyBirthdaySheetAndPlaySong();
    }

    void ShowImageAndPlaySoundEffect() {
        audios[0].Play();
        ShowItemImage();
    }

    void HideImageAndShowMessage() {
        HideItemImage();
        ShowPlayerUIMessage();
    }

    void HideMessageAndYarnFalls() {
        HidePlayerUIMessage();
        SingleYarnFalls();
    }

    void SingleYarnFalls() {
        ball.SetActive(true);
    }
    protected void ShowPlayerUIMessage2()
    {
        Debug.Log("show");
        PlayerUI_TextCtrl.self.ShowText();
        DelayThenDoNext(2f);
    }
    protected void HidePlayerUIMessage2()
    {
        PlayerUI_TextCtrl.self.HideText();
        DelayThenDoNext(2f);
    }
}
