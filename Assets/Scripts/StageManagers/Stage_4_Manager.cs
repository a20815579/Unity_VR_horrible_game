using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_4_Manager : StageManager
{
    [SerializeField]
    AudioSource audio;
    [SerializeField]
    GameObject ball;

    public override void SetupEvents()
    {
        Debug.Log("Stage 4 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:button down -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene


        AddEvent(0, ShowPlayerUIMessage);   
        // 0: show message: os：咦？我怎麼突然移動到學長的房間了...?!!
        
        AddEvent(1, ShowPlayerUIMessage);   
        // 1: button down -> show message: os：今天一直遇到奇怪的事情，好可怕...
        
        AddEvent(2, ShowPlayerUIMessage);   
        // 2: button down -> show message: os：看來現在只能繼續尋找學長自殺的線索了
        
        AddEvent(3, HidePlayerUIMessage);   
        // 3: button down -> hide message
        
        AddEvent(4, ShowImageAndPlaySoundEffect);         
        // 4: select on medical box -> show image of medical box and play sound
        
        AddEvent(5, HideImageAndShowMessage);  
        // 5: button down -> hide imgage -> show message: 室友：哦...那是最近被矛求打傷去買的。
        
        AddEvent(6, ShowPlayerUIMessage);   
        // 6: button down -> show message: 室友：之前他跟我借資結作業抄，
        
        AddEvent(7, ShowPlayerUIMessage);   
        // 7: button down -> show message: 室友：我怕被抓到0分不敢借他，結果就被他打了
        
        AddEvent(8, HidePlayerUIMessage);   
        // 8: button down -> hide message
        
        AddEvent(9, ShowImageAndPlaySoundEffect);
        // 9: select on cat -> show image of cat and play sound 
        
        AddEvent(10, HideImageAndShowMessage);
        // 10: button down -> hide imgage-> show message: 室友：那...那是矛求最近偷偷養的，
        
        AddEvent(11, ShowPlayerUIMessage);   
        // 11: button down -> show message: 室友：你不準告訴其他人，不然會害我被退宿
        
        AddEvent(12, HideMessageAndYarnFalls);   
        // 12: button down -> hide message and yarn falls
        
        AddEvent(13, ShowPlayerUIMessage);   
        // 13: button down -> show message: 室友：你怎麼突然很驚恐地往那邊看??
        
        AddEvent(14, ShowPlayerUIMessage);   
        // 14: button down -> show message: 室友：那邊根本沒東西啊...
        
        AddEvent(15, ShowPlayerUIMessage);   
        // 15: button down -> show message: 室友：啊！矛求在一個月前也是突然這樣，
    
        AddEvent(16, ShowPlayerUIMessage);   
        // 16: button down -> show message: 室友：從那之後，他就越來越奇怪，
        
        AddEvent(17, ShowPlayerUIMessage);   
        // 17: button down -> show message: 室友：而且變得很容易暴怒，
        
        AddEvent(18, ShowPlayerUIMessage);   
        // 18: button down -> show message: 室友：不然他本來不是這樣的人...
        
        AddEvent(19, HidePlayerUIMessage);   
        // 19: button down -> hide message
        
        //AddEvent(20, ShowImageAndPlaySoundEffect);   
        // 20: select on diary -> show image of diary and play sound
        
        //AddEvent(21, TurnDiaryToMultipleYarnsAndFallsAndTransitionToNextScene);   
        // 20: button down -> hide image and diary become yarns and fall and transition to next scene after some delays

        ReactOnInput(0); //uncomment this line if first event needs to start defaultly
    }

    void ShowImageAndPlaySoundEffect() {
        audio.Play();
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
    void TurnDiaryToMultipleYarnsAndFallsAndTransitionToNextScene() {

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
