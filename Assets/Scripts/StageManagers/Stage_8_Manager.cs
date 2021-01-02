using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage_8_Manager : StageManager
{
    [SerializeField]
    HappyBirthdaySheetCtrl happyBirthdaySheetCtrl;
    [SerializeField]
    GameObject lights;
    public FriendAnimCtrl[] friends;

    [HideInInspector] 
    public bool isBlocking = false;

    public override void SetupEvents()
    {
        Debug.Log("Stage 8 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:button down -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene

        // total event: 9
        // touch event(8): 0 1 3 4 5 6 7 8 
        // text event(5) 
        // show image(1): 0

        AddEvent(0, ShowImageAndPlaySoundEffect);   
        // 0: button down -> show UI: 彈生日快樂歌給毛球吧

        AddEvent(1, HideImageAndShowSheetThenPlaySong);
        // 1: button down -> hide image and play song

        AddEvent(2, WaterPoolIgnite);
        // 2: water pool collides with ball -> water pool ignites

        AddEvent(3, ShowPlayerUIMessage);
        // 3: button down -> show message: 毛球: 謝謝你們幫我完成生前的心願

        AddEvent(4, ShowPlayerUIMessage);
        // 4: button down -> show message: 毛球: 消除我對人世的遺恨

        AddEvent(5, ShowPlayerUIMessage);
        // 5: button down -> show message: 毛球: 能夠像這樣被一群人慶生和丟進成功湖裡真開心!

        AddEvent(6, ShowPlayerUIMessage);
        // 6: button down -> show message: 毛球: 我也該好好離開人世了

        AddEvent(7, ShowPlayerUIMessage);
        // 7: button down -> show message: 毛球: 謝謝你們，再見！！

        AddEvent(8, HideMessageAndSceneFadeout);
        // 8: button down -> hide message and screen fadeout

        StartCoroutine(RunEntireFlow(9));
    }
    
    IEnumerator RunEntireFlow(int n) {
        for (int i = 0; i < n; i++) {
            ReactOnInput(i);
            yield return new WaitForSeconds(15.0f);
        }
    }

    void HideMessageAndSceneFadeout() {
        HidePlayerUIMessage();
        TransitionToNextScene();
    }

    void WaterPoolIgnite() {
        lights.SetActive(true);
    }

    void HideImageAndShowSheetThenPlaySong() {
        isBlocking = true;

        HideItemImage();
        BGM_player.Stop();
        happyBirthdaySheetCtrl.ShowHappyBirthdaySheetAndPlaySong();

        float audioLength = happyBirthdaySheetCtrl.audio.clip.length;
        
        Invoke("HappyBirthdaySongFinished", audioLength + 0.5f);
    }

    void HappyBirthdaySongFinished() {
        PlaySFX();

        happyBirthdaySheetCtrl.HideHappyBirthdaySheet();

        BGM_player.Play();

        isBlocking = false;

        for(int i=0; i<friends.Length; i++)
        {
            friends[i].Clap(true);
        }
    }

    void ShowImageAndPlaySoundEffect() {
        PlaySFX();
        ShowItemImage();
    }

    void HideImageAndShowMessage() {
        HideItemImage();
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
