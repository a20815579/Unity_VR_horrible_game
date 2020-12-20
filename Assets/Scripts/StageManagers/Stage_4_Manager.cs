using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_4_Manager : StageManager
{
    AudioSource audio;
    [SerializeField]
    GameObject ball;

    public override void SetupEvents()
    {
        Debug.Log("Stage 4 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:keyDown -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene



        AddEvent(0, ShowPlayerUIMessage2);   // 0: show message
        AddEvent(1, ShowPlayerUIMessage2);   // 1: keyDown -> show message
        AddEvent(2, ShowPlayerUIMessage2);   // 2: keyDown -> show message
        AddEvent(3, HidePlayerUIMessage2);   // 3: keyDown -> hide message
        AddEvent(4, ShowPlayerUIMessage2);   // 4: select on medical box  -> show message
        AddEvent(5, HidePlayerUIMessage2);   // 5: keyDown -> hide message
        AddEvent(6, ShowPlayerUIMessage2);   // 6: select on cat -> show message
        AddEvent(7, HideMessageAndYarnFalls);   // 7: keyDown -> hide message and yarn falls
        AddEvent(8, ShowPlayerUIMessage2);   // 8: delay -> show message
        AddEvent(9, ShowPlayerUIMessage2);   // 9: keyDown -> show message
        AddEvent(10, ShowPlayerUIMessage2);   // 10: keyDown -> show message
        AddEvent(11, HidePlayerUIMessage2);   // 11: keyDown -> hide message
        AddEvent(12, ShowPlayerUIMessage2);   // 12: select on diary -> show message
        AddEvent(13, ShowPlayerUIMessage2);   // 13: keyDown -> show message
        AddEvent(14, ShowPlayerUIMessage2);   // 14: keyDown -> show message
        AddEvent(15, ShowPlayerUIMessage2);   // 15: keyDown -> show message
        AddEvent(16, ShowPlayerUIMessage2);   // 16: keyDown -> show message
        AddEvent(17, ShowPlayerUIMessage2);   // 17: keyDown -> show message
        AddEvent(18, ShowPlayerUIMessage2);   // 18: keyDown -> show message
        AddEvent(19, ShowPlayerUIMessage2);   // 19: keyDown -> show message
        AddEvent(20, ShowPlayerUIMessage2);   // 20: keyDown -> show message
        AddEvent(21, HideMessageAndTurnDiaryToMultipleYarnsAndFalls);   
                                // 21: keyDown -> hide message and diary become yarn and falls            
        AddEvent(22, DarkenScreen);   // 22: delay -> screen become black
        AddEvent(23, TransitionToNextScene);   // 23: delay -> transition to next scene

        ReactOnInput(0); //uncomment this line if first event needs to start defaultly
        ReactOnInput(1);
        ReactOnInput(2);
        ReactOnInput(3);
        ReactOnInput(4);
        ReactOnInput(5);
    }

    void HideMessageAndYarnFalls() {
        HidePlayerUIMessage();
        SingleYarnFalls();
    }

    void SingleYarnFalls() {
        ball.SetActive(true);
    }
    void TurnDiaryToMultipleYarnsAndFalls() {

    }

    void HideMessageAndTurnDiaryToMultipleYarnsAndFalls() {
        HidePlayerUIMessage();
        TurnDiaryToMultipleYarnsAndFalls();
    }

    void DarkenScreen() {

    }
    void ShowMessageAndPlaySoundEffect() {
        audio.Play();
        ShowPlayerUIMessage();
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
