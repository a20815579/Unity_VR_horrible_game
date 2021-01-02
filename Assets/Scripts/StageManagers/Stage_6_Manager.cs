using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_6_Manager : StageManager
{
    /*場景6：成功湖
        (M2 播放到本場景結束)
        道具：蛋糕
        角色：主角的朋友們
        主角：咦? 你們怎麼都在這裡
        朋友們：今天是你的生日啊，生日快樂！(唱生日快樂歌) ( S06 )(或是加長版 S06_2)
        主角：謝謝你們...有你們真好！你們會一直陪在我身邊吧~
        朋友A：咦? 當然啊~ 你怎麼看起來臉色不太好...?不然來個擁抱吧(雙臂展開)
        走到朋友A面前，做出擁抱姿勢後點擊手把
        朋友A身首分離，倒在地上
        傳來哀怨的聲音「為什麼你有朋友幫你慶生...我卻孤單一人...」
        其他朋友也身首分離倒在地上 (S09)
        畫面變全黑，然後移動到444
     */

    public FriendAnimCtrl[] friends;
    public OpenArmCtrl openArm;
    public Animator LonelyVoiceAnim;
    public override void SetupEvents()
    {
        AddEvent(0, DelayThenShowMessage); // 主角：咦? 你們怎麼都在這裡
        AddEvent(1, ClapAndShowMessage); //click-> 朋友們：今天是你的生日啊，生日快樂！
        AddEvent(2, PlayBirthdaySong); //Delay->Play Birthday song
        AddEvent(3, StopClappingAndShowMessage); //Delay->主角：謝謝你們...有你們真好！
        AddEvent(4, ShowPlayerUIMessage); //click->主角：你們會一直陪在我身邊吧~
        AddEvent(5, ShowPlayerUIMessage); //click->朋友A：咦? 當然啊~
        AddEvent(6, ShowPlayerUIMessage); //click->朋友A：你怎麼看起來臉色不太好...?
        AddEvent(7, ShowMessageAndOpenArms); //click->朋友A：不然來個擁抱吧+OpenArms
        AddEvent(8, DropHead); //走到朋友A面前，做出擁抱姿勢後click->Seperate
        AddEvent(9, LonelyVoice); //delay->showMessage
        AddEvent(10, AllDropHead); //delay->allSeperate+PlaySFX
        AddEvent(11, TransitionToNextScene); //delay->nextScene

        ReactOnInput(0);
    }

    void DelayThenShowMessage()
    {
        PlayBGM();
        openArm.Wave();
        Delay(1f, ShowPlayerUIMessage);
    }
    void ClapAndShowMessage()
    {
        for(int i=0; i<friends.Length; i++)
        {
            friends[i].Clap(true);
        }
        ShowPlayerUIMessage();
        DelayThenDoNext(1.5f);
    }

    void PlayBirthdaySong()
    {
        PlaySFX();
        DelayThenDoNext(8f);
    }

    void StopClappingAndShowMessage()
    {
        for (int i = 0; i < friends.Length; i++)
        {
            friends[i].Clap(false);
        }
        ShowPlayerUIMessage();
    }

    void ShowMessageAndOpenArms()
    {
        ShowPlayerUIMessage();
        Delay(0.5f, OpenArms);
    }

    void OpenArms()
    {
        openArm.OpenArm();
    }
    
    void DropHead()
    {
        HidePlayerUIMessage();
        friends[0].DropHead();
        PlaySFX(); //S19
        PlayBGM();
        DelayThenDoNext(3f);

    }
    void LonelyVoice()
    {
        LonelyVoiceAnim.enabled = true;
        DelayThenDoNext(8.5f);
    }

    void AllDropHead()
    {
        PlaySFX();
        for (int i = 1; i < friends.Length; i++)
        {
            friends[i].DropHead();
        }
        Delay(1.15f, PlaySFX); //S09

        DelayThenDoNext(3f);
    }
    
}
