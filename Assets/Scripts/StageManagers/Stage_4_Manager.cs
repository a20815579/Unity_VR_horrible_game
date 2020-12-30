using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage_4_Manager : StageManager
{
    [SerializeField]
    AudioSource[] audios;
    [SerializeField]
    GameObject ball;
    [SerializeField]
    GameObject diaryCloseed;
    [SerializeField]
    GameObject diaryOpend;
    [SerializeField]
    Diary_close_controller diary_Close_Controller;
    [SerializeField]
    Diary_open_controller diary_Open_Controller;
    [SerializeField]
    DiaryDisappearCtrl diary_disappear;

    public override void SetupEvents()
    {
        Debug.Log("Stage 4 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:button down -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene

        // total event: 24
        // touch event(21): 1 2 3 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 21 22 23
        // text event(14)
        // show image(2): 4 9

        AddEvent(0, ShowPlayerUIMessage);   
        // 0: show message: 咦？我怎麼突然移動到學長的房間了...?!!
        
        AddEvent(1, ShowPlayerUIMessage);   
        // 1: button down -> show message: 今天一直遇到奇怪的事情，好可怕...
        
        AddEvent(2, ShowPlayerUIMessage);   
        // 2: button down -> show message: 看來現在只能繼續尋找學長自殺的線索了
        
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
        
        AddEvent(20, ChangeDiaryToOpenAndPlaySoundEffect);   
        // 20: select on diary -> diary open

        // grab diary

        AddEvent(21, diary_Open_Controller.NextPage);   
        // 21: trigger button down -> diary change page

        AddEvent(22, diary_Open_Controller.NextPageAgain);   
        // 22: trigger button down -> diary change page again

        AddEvent(23, DiaryFadeoutAndYarnsFall);   
        // 23: trigger button down -> diary become yarns and fall, then transition to next scene

        ReactOnInput(0); //uncomment this line if first event needs to start defaultly
        //StartCoroutine(RunEntireFlow(24));
    }

    IEnumerator RunEntireFlow(int n) {
        for (int i = 0; i < 19; i++) {
            ReactOnInput(i);
        }

        for (int i = 19; i < n; i++) {
            ReactOnInput(i);
            yield return new WaitForSeconds(2.0f);
        }
    }

    void ChangeDiaryToOpenAndPlaySoundEffect() {
        audios[0].Play();
        diary_Close_Controller.ChangeToOpen();
    }

    void ShowImageAndPlaySoundEffect() {
        audios[0].Play();
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
    
    IEnumerator MultipleYarnsFadeInAndFall(int n) {
        float soundDecSpeed = 0.03f;
        for (int i = 0; i < n; i++) {
            audios[1].volume -= soundDecSpeed;
            Debug.Log(audios[1].volume);

            Vector3 diaryPos = diaryOpend.transform.position;
            Vector3 pos = new Vector3(
                diaryPos.x + Random.Range(-0.3f, 0.3f),
                diaryPos.y + Random.Range(-0.3f, 0.3f),
                diaryPos.z + Random.Range(-0.3f, 0.3f)
            );
            Instantiate(ball, pos, diaryOpend.transform.rotation);

            yield return new WaitForSeconds(0.2f);
        }
        
        audios[1].Stop();

        TransitionToNextScene();
    }

    void DiaryFadeoutAndYarnsFall() {
        // 20 balls
        int n = 20;
        audios[1].Play();
        StartCoroutine(MultipleYarnsFadeInAndFall(n));

        diary_disappear.FadeOut();
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
