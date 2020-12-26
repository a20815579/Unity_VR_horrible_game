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

        // total event: 18
        // touch event(10): 1 3 4 5 7 8 9 10 11 13 14 15 16 17
        // text event(11)
        // show image(3): 2 6 12

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
        // 7: button down -> hide image -> show message: 室友：矛求之前通宵趕資結作業，

        AddEvent(8, ShowPlayerUIMessage);  
        // 8: button down -> show message: 室友：結果卻因為換行符號不一樣就沒分數，

        AddEvent(9, ShowPlayerUIMessage);  
        // 9: button down -> show message: 室友：助教一開始也沒講清楚環境是linux還是windows，

        AddEvent(10, ShowPlayerUIMessage);  
        // 10: button down -> show message: 室友：讓矛求很生氣

        AddEvent(11, HidePlayerUIMessage);  
        // 11: button down -> hide message
        
        AddEvent(12, ShowImageAndPlaySoundEffect);         
        // 12: select on wine bottle -> show item image and play sound
        
        AddEvent(13, HideImageAndShowMessage);   
        // 13: button down -> hide image -> show message: 室友：矛求以前都理性飲酒的，

        AddEvent(14, ShowPlayerUIMessage);   
        // 14: button down -> hide image -> show message: 室友：但他最近壓力很大，常常一喝就是好幾瓶，還會發酒瘋。
        
        AddEvent(15, ShowPlayerUIMessage);   
        // 15: button down -> show message: OS：嗯...。看來矛求學長是因為課業不順才跳樓的... 
        
        AddEvent(16, ShowPlayerUIMessage);   
        // 16: button down -> show message: OS：我還是回去念書，免得跟他一樣 
        
        AddEvent(17, TransitionToNextScene);   
        // 17: button down -> transition to next scene

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
