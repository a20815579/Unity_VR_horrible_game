using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_1_Manager : StageManager
{
    /*
        場景1：944
        第一章： 祭
        玩家在宿舍內聽到怪聲 (S01) 
        OS：是風聲嗎...？去關個窗戶好了
        面對窗戶，目睹學生跳樓
        (彈出對話框，音效) (S07) (M0 播放到本場景結束) 
        未知1：...啊！有人從頂樓跳下來！！
        未知2：他...他的......頭...呢？
        未知3：這衣服是...學...學長？！矛求學長？！
        (往桌上看)
        桌面浮出血字「你必須調查真相...不然下一個人...就是你...」(S03)
        OS：為...為什麼我的桌面會跑出這個？！天哪...怎麼會這樣...好害怕...
        不然我先照著上面的指示做好了...那位學長好像是住844，去問問看他的室友，看會不會有什麼線索 (S12)然後播(S13)
    */
    public FallManCtrl fallMan;
    public Word_0_Ctrl word;

    public override void SetupEvents()
    {
        Debug.Log("Stage 1 event setup");

        /* add event-triggered functions to delegate list */
        AddEvent(0, WierdSound); //play wierd sound -> delay(1s)
        AddEvent(1, ShowPlayerUIMessage); //show message: OS：是風聲嗎...？去關個窗戶好了 ->wait for click window
        AddEvent(2, HidePlayerUIMessage); //nextLine -> hide message ->wait for click window
        AddEvent(3, StudentFall); //click window -> StudentFall ->Delay(1s)
        AddEvent(4, ShowPlayerUIMessage); //(X)->未知1：...啊！有人從頂樓跳下來！！
        AddEvent(5, ShowPlayerUIMessage); //nextLine->未知2：他...他的......頭...呢？
        AddEvent(6, ShowPlayerUIMessage); //nextLine->未知3：這衣服是...學...學長？！矛求學長？！
        AddEvent(7, EnableWord); //nextLine->enableWord + hide message
        AddEvent(8, GazeAtWord); //gaze at word->為...為什麼我的桌面會跑出這個？！
        AddEvent(9, ShowPlayerUIMessage); //nextLine->天哪...怎麼會這樣...好害怕...
        AddEvent(10, ShowPlayerUIMessage); //nextLine->不然我先照著上面的指示做好了...
        AddEvent(11, ShowPlayerUIMessage); //nextLine->那位學長好像是住844，去問問看他的室友，看會不會有什麼線索
        AddEvent(12, NextScene); //nextLine->next scene
        ReactOnInput(0);
    }

    private void WierdSound()
    {
        PlaySFX();
        DelayThenDoNext(1f);
    }

    private void StudentFall()
    {
        fallMan.Fall();
        Debug.Log("student fall");
        Delay(0.5f, PlaySFX);
        Delay(1f, PlayBGM);
        DelayThenDoNext(1f);
    }

    private void EnableWord()
    {
        HidePlayerUIMessage();
        word.enabled = true;
    }

    private void GazeAtWord()
    {
        PlaySFX();
        ShowPlayerUIMessage();
    }

    void NextScene()
    {
        TransitionToNextScene();
        Delay(1f, PlaySFX);
        Delay(1f, PlaySFX);
    }
    
}
