﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_5_Manager : StageManager
{
    public FoIn_vanish[] foIn_Vanish;
    public Diary_close_controller diary_close_controller;
    public Diary_open_controller diary_open_controller;
    // Start is called before the first frame update
    public override void SetupEvents()
    {

        /* add event-triggered functions to delegate list */
        AddEvent(0, ShowPlayerUIMessage); //click -> 咦...？744？
        AddEvent(1, ShowPlayerUIMessage); //click -> 七樓有這個房間...?
        AddEvent(2, HidePlayerUIMessage); // click -> hide UI
        AddEvent(3, FoInVanish1); //click foIn -> Vanish
        AddEvent(4, FoInVanish2); //click foIn -> Vanish
        AddEvent(5, DoNothing); // click FuChao -> do nothing
        AddEvent(6, OpenDiary); //click diary -> show 744同學的日記 & open diary
        AddEvent(7, HideItemImage); //click -> hide UI
        AddEvent(8, DiaryNextPage); //trigger diary -> show 2019/12/19&21
        AddEvent(9, ShowPlayerUIMessage); //click -> 竟然跟矛求學長的日記內容一模一樣..！！該不會他後來跟矛求學長一樣自殺...
        AddEvent(10, ShowPlayerUIMessage); //click -> 然後...這就是傳說中鬧鬼後被學校封閉的房間...
        AddEvent(11, ShowPlayerUIMessage); //click -> 天哪！這整件事也太毛骨悚然！！學長們怎麼會遇上這種事......
        AddEvent(12, HidePlayerUIMessage); // click -> hide UI
        AddEvent(13, DiaryBloodMsg); //trigger diary -> show blood msg
        AddEvent(14, DiaryBloodMsg2); //show blood msg2
        AddEvent(15, ShowPlayerUIMessage); //click -> 什...什麼意思！！！
        AddEvent(16, ShowPlayerUIMessage); //click -> 啊.......
        AddEvent(17, ShowPlayerUIMessage); //click -> 矛求學長住844房，這位一年前自殺的學長住744房...
        AddEvent(18, ShowPlayerUIMessage); //click -> 那這樣...下一個不就是住在944的我嗎！！
        AddEvent(19, ShowPlayerUIMessage); //click -> 怎麼會有這種事......太可怕了......太荒謬了......
        AddEvent(20, ShowPlayerUIMessage); //click -> 如果詛咒是從444房開始的，那這件事已經持續五年了...，我不想當下一個人啊啊！！
    }
    void FoInVanish1()
    {
        foIn_Vanish[0].Vanish();
    }
    void FoInVanish2()
    {
        foIn_Vanish[1].Vanish();
    }
    void DoNothing()
    {

    }
    void OpenDiary()
    {
        ShowItemImage();
        diary_close_controller.ChangeToOpen();
    }
    void DiaryNextPage()
    {
        diary_open_controller.NextPage();
    }
    void DiaryBloodMsg()
    {
        diary_open_controller.BloodMsg();
        DelayThenDoNext(1f);
    }
    void DiaryBloodMsg2()
    {
        diary_open_controller.BloodMsg2();
        DelayThenDoNext(1f);
    }
}
