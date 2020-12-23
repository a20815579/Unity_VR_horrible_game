using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;
public class Stage_3_Manager : StageManager
{
    /*
        場景3：944 
        桌上有螢幕，腳邊是桌電主機 (M6 播放到"地上有毛球"前)
        主角：還是趕快來寫資結作業吧
        提示 ：點擊電腦(S02)
        點完後螢幕出現code
        (S14)
        主角：AVL tree 好難...，測資一直沒有過，希望今天可以趕快debug完
        螢幕顯示血字「這不是真相...你還要繼續調查...」(S03)
        主角：這到底怎麼回事！讓我做作業啊！
        (嘗試點擊螢幕 但都沒反應) (S15)
        (感應點到螢幕後，delay2秒顯示) 主角：還是去按強制重新開機鍵看看能不能讓螢幕變正常...
        往主機看過去，地上有奇怪東西(毛球) (S04)
        (當camera轉向毛球) 主角：咦?這是什麼?  (M0 播放到本場景結束)
        當毛球被拿到約胸前的位置時，毛球轉過來，是一顆血淋淋的人頭(搭配音效) (S08)，掉落地上
        主角：啊！！！是人頭！！為什麼房間裡會突然有一顆人頭！
	        等等...昨天跳樓的矛求學長，他的屍體...沒有頭...
        (看向毛球)毛球消失(看能不能家個消失動畫)
        毛球消失的地方，有「孤單的人生...好黑暗...」的血字 (S03)
        房間慢慢變暗(搭配音效)
        移動到844

    */
    public MonitorCtrl monitor;
    public Word_1_Ctrl word;
    public GameObject Ball;

    public override void SetupEvents()
    {
        Debug.Log("Stage 1 event setup");

        /* add event-triggered functions to delegate list */
        AddEvent(0, PlayBGM_M6); // (x)->PlayBGM
        AddEvent(1, ShowPlayerUIMessage); // (x)->還是趕快來寫資結作業吧
        AddEvent(2, ClickMonitor); // click monitor -> PlaySFX(S02)+出現code
        AddEvent(3, TypingKeyboard); // (x)->PlaySFX(S14) + ShowMessage
        AddEvent(4, ShowBloodWord); // delayNext->word appear+PlaySFX(S03)
        AddEvent(5, HidePlayerUIMessage); // GripBtn->HideMessage
        AddEvent(6, TryClickMonitor); // click monitor->HideMessage+PlaySFX(S15)
        AddEvent(7, EnableBall); // GripBtn->HideMessage + ball set active
        AddEvent(8, GazeAtBall); //gaze at ball->show message + SFX(S04)+BGM(M0)
        AddEvent(9, DropBall); //pickUpball->show message + SFX(S08)



        ReactOnInput(0);
    }

    private void PlayBGM_M6()
    {
        PlayBGM();
        DelayThenDoNext(1f);
    }
    
    private void ClickMonitor()
    {
        PlaySFX();
        monitor.ShowCode(true);
        HidePlayerUIMessage();
        DelayThenDoNext(3f);

    }

    private void TypingKeyboard()
    {
        PlaySFX();
        Delay(1.5f, ShowPlayerUIMessage);
        DelayThenDoNext(6f);
    }
    
    private void ShowBloodWord()
    {
        monitor.ShowCode(false);
        word.Appear();
        Delay(0.5f, PlaySFX); //S03
        Delay(2.5f, ShowPlayerUIMessage);// 主角：這到底怎麼回事！讓我做作業啊！
    }

    private void TryClickMonitor()
    {
        PlaySFX(); //S15
        Delay(2.5f, ShowPlayerUIMessage); //還是去按強制重新開機鍵看看能不能讓螢幕變正常...
    }

    private void EnableBall()
    {
        Ball.SetActive(true); //ball appear
        HidePlayerUIMessage();
    }

    private void GazeAtBall()
    {
        //Debug.Log("Gaze");
        PlaySFX();//S04
        Delay(1f, PlayBGM); //M0
        ShowPlayerUIMessage();//咦?這是什麼? 
    }

    void DropBall()
    {
        ShowPlayerUIMessage();
        PlaySFX();
    }
}
