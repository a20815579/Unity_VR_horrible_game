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


        AddEvent(0, ShowPlayerUIMessage);   // 0: show message
        AddEvent(1, HidePlayerUIMessage);   // 1: button down -> hide message
        AddEvent(2, ShowItemImage);         // 2: select on exam paper -> show item image
        AddEvent(3, HideImageAndShowMessage);   // 3: button down -> hide image -> show message
        AddEvent(4, HidePlayerUIMessage);   // 4: button down -> hide message
        AddEvent(5, ShowItemImage);         // 5: select on computer monitor -> show item image
        AddEvent(6, HideImageAndShowMessage);   // 6: button down -> hide image -> show message
        AddEvent(7, HidePlayerUIMessage);   // 7: button down -> hide message
        AddEvent(8, ShowItemImage);         // 8: select on wine bottle -> show item image
        AddEvent(9, HideImageAndShowMessage);   // 9: button down -> hide image -> show message
        AddEvent(10, ShowPlayerUIMessage);   // 10: button down -> show message
        AddEvent(11, ShowPlayerUIMessage);   // 11: button down -> show message
        AddEvent(12, TransitionToNextScene);   // 12: button down -> transition to next scene

        ReactOnInput(0); //uncomment this line if first event needs to start defaultly
    }

    void HideImageAndShowMessage() {
        HideItemImage();
        ShowPlayerUIMessage();
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
