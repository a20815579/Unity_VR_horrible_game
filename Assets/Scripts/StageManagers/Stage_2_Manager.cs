using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_2_Manager : StageManager
{
    AudioSource audio;

    public override void SetupEvents()
    {
        Debug.Log("Stage 2 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:keyDown -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene


        AddEvent(0, ShowPlayerUIMessage2);   // 0: show message
        AddEvent(1, HidePlayerUIMessage2);   // 1: keyDown -> hide message
        AddEvent(2, ShowPlayerUIMessage2);   // 2: select on exam paper -> show message
        AddEvent(3, HidePlayerUIMessage2);   // 3: keyDown -> hide message
        AddEvent(4, ShowPlayerUIMessage2);   // 4: select on computer monitor -> show message
        AddEvent(5, HidePlayerUIMessage2);   // 5: keyDown -> hide message
        AddEvent(6, ShowPlayerUIMessage2);   // 6: keyDown on wine bottle -> show message
        AddEvent(7, ShowPlayerUIMessage2);   // 7: keyDown -> show message
        AddEvent(8, ShowPlayerUIMessage2);   // 8: keyDown -> show message
        AddEvent(9, ShowPlayerUIMessage2);   // 9: keyDown -> show message
        AddEvent(10, TransitionToNextScene);   // 10: keyDown -> transition to next scene

        ReactOnInput(0); //uncomment this line if first event needs to start defaultly
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
