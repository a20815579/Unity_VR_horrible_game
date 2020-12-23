using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_2_Manager : StageManager
{
    [SerializeField]
    AudioSource audio;

    public override void SetupEvents()
    {
        Debug.Log("Stage 2 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:keyDown -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene


        AddEvent(0, ShowPlayerUIMessage);   
        // 0: show message: 室友：怎麼會發生這種事...
        
        AddEvent(1, HidePlayerUIMessage);   
        // 1: button down -> hide message
        
        AddEvent(2, ShowImageAndPlaySoundEffect);         
        // 2: select on exam paper -> show item image and play sound
        
        AddEvent(3, HideImageAndShowMessage);   
        // 3: button down -> hide image -> show message: 室友：哦那是矛求工數(暫定)考爆的考卷，
        
        AddEvent(4, HidePlayerUIMessage);  
        // 4: button down -> show message: 室友： 雖然他在考前很認真讀，但最後還是沒考好...

        AddEvent(5, HidePlayerUIMessage);   
        // 5: button down -> hide message
        
        AddEvent(6, ShowImageAndPlaySoundEffect);         
        // 6: select on computer monitor -> show item image and play sound
        
        AddEvent(7, HideImageAndShowMessage);   
        // 7: button down -> hide image -> show message: 室友：矛求之前通宵趕資結作業，結果卻因為換行符號不一樣就沒分數，助教一開始也沒講
        
        AddEvent(8, HidePlayerUIMessage);  
        // 8: button down -> hide message
        
        AddEvent(9, ShowImageAndPlaySoundEffect);         
        // 9: select on wine bottle -> show item image and play sound
        
        AddEvent(10, HideImageAndShowMessage);   
        // 10: button down -> hide image -> show message
        
        AddEvent(11, ShowPlayerUIMessage);   
        // 11: button down -> show message
        
        AddEvent(12, ShowPlayerUIMessage);   
        // 12: button down -> show message
        
        AddEvent(13, TransitionToNextScene);   
        // 13: button down -> transition to next scene

        ReactOnInput(0); //uncomment this line if first event needs to start defaultly
    }

    void HideImageAndShowMessage() {
        HideItemImage();
        ShowPlayerUIMessage();
    }

    void ShowImageAndPlaySoundEffect() {
        audio.Play();
        ShowItemImage();
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
