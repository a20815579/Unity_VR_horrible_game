using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_7_Manager : StageManager
{
    /*
        場景7：444
        第五章：詛咒的來源
        場景同744 (M4 播放到本場景結束)
        主角：這...這裡是...444?? 我竟然來到了詛咒發源的房間...
	        雖然不知為何突然來到這裡，總之先來找找看線索好了
        雖然感覺這裡很可怕...
        點擊封印和日記，發出紅光
        桌面浮出一顆毛球(音效)
        (全屏顯示)
        為什麼我會沒有朋友！為什麼你們都不理我！！
        死後我一定要化成鬼魂，讓你們嘗嘗孤單的滋味！！
        毛球、符咒和封印淡出
        點擊日記
        顯示：444房毛球同學生前的日記
        2016/12/21：今天經過成功湖時，看到有一群人在慶生，壽星還被丟到湖裡...我也好想要有人幫我這樣慶生......，其實今天也是我的生日啊！我卻只能孤單一人...
        主角：啊！！也許可以試試看這麼做！
        可是要怎麼樣才能找到一群人幫忙慶生呢... 
        有了！可以在二手版徵人看看！
        UI顯示徵人圖(celebrate.png)
        主角：希望可以徵的到人...
        移動成功湖

     */

    [SerializeField]
    GameObject ball, celebrate;
    [SerializeField]
    Animator WordsAnim;
    [SerializeField]
    Diary_close_controller diary_Close_Controller;

    public override void SetupEvents()
    {
        AddEvent(0, ShowPlayerUIMessage); //(X)->這...這裡是...444?? 
        AddEvent(1, ShowPlayerUIMessage); //click->我竟然來到了詛咒發源的房間...
        AddEvent(2, ShowPlayerUIMessage); //click->雖然不知為何突然來到這裡，總之先來找找看線索好了...
        AddEvent(3, ShowPlayerUIMessage); //click->雖然感覺這裡很可怕...
        AddEvent(4, HidePlayerUIMessage); //click->hide Message

        AddEvent(5, ThingsTurnRed); //click FuChaoMain->ThingsTurnRed
        AddEvent(6, BallAppear); //delay->BallAppear + PlaySFX
        AddEvent(7, ShowWords); //delay->ShowWords
        AddEvent(8, ThingsDisappear); //delay->ThingsDisappear
        AddEvent(9, ChangeDiaryToOpenAndPlaySoundEffect);//click diary -> diary open

        // grab diary

        AddEvent(10, ShowPlayerUIMessage);//Diary OnSelectExit -> 原來是因為很孤單又沒有人幫他慶生才自殺的QQ
        AddEvent(11, ShowPlayerUIMessage);//click -> 可是要怎麼樣才能找到一群人幫忙慶生呢...                                    
        AddEvent(12, ShowPlayerUIMessage);//click -> 有了！可以在二手版徵人看看！                                    
        AddEvent(13, ShowCelebrateImg);//click -> 徵人                            
        AddEvent(14, HideCelebrateImg);//click -> 希望可以徵的到人... 

        ReactOnInput(0); 
    }
    private void ThingsTurnRed()
    {
        GetComponent<ThingsColorCtrl>().TurnRed();
        PlaySFX();
        DelayThenDoNext(3f);
    }
    private void BallAppear()
    {
        ball.SetActive(true);
        ball.GetComponent<BallAppearCtrl>().FadeIn();
        PlaySFX();
        DelayThenDoNext(3f);
    }


    private void ShowWords()
    {
        WordsAnim.enabled = true;
        DelayThenDoNext(8.5f);
    }


    private void ThingsDisappear()
    {
        GetComponent<ThingsColorCtrl>().FadeOut();
    }

    void ChangeDiaryToOpenAndPlaySoundEffect()
    {
        PlaySFX();
        ShowItemImage();
        Delay(1f, diary_Close_Controller.ChangeToOpen);
        Delay(3f, HideItemImage);
    }
    void DoNothing()
    {

    }
    void ShowCelebrateImg()
    {
        celebrate.SetActive(true);
    }

    void HideCelebrateImg()
    {
        celebrate.SetActive(false);
        ShowPlayerUIMessage();
        Delay(2f, TransitionToNextScene);
    }
}
