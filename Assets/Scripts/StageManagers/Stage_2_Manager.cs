using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_2_Manager : StageManager
{
    public override void SetupEvents()
    {
        Debug.Log("Stage 2 event setup");
        
        /* add event-triggered functions to delegate list */
        //AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        //AddEvent(1, HidePlayerUIMessage); //1:keyDown -> hide message -> wait for click window
        //AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        //AddEvent(3, TransitionToNextScene); //3:click monitor -> next scene

        //ReactOnInput(0); //uncomment this line if first event needs to start defaultly

        AddEvent(0, ShowPlayerUIMessage);   // 0: keyDown on roommate -> show message
        AddEvent(1, ShowPlayerUIMessage);   // 1: keyDown -> show message
        AddEvent(2, HidePlayerUIMessage);   // 2: keyDown -> hide message
        AddEvent(3, ShowPlayerUIMessage);   // 3: keyDown on exam paper -> show message
        AddEvent(4, ShowPlayerUIMessage);   // 4: keyDown -> show message
        AddEvent(5, HidePlayerUIMessage);   // 5: keyDown -> hide message
        AddEvent(6, ShowPlayerUIMessage);   // 6: keyDown on monitor -> show message
        AddEvent(7, ShowPlayerUIMessage);   // 7: keyDown -> show message
        AddEvent(8, HidePlayerUIMessage);   // 8: keyDown -> hide message
        AddEvent(9, ShowPlayerUIMessage);   // 9: keyDown on wine bottle -> show message
        AddEvent(10, ShowPlayerUIMessage);   // 10: keyDown -> show message
        AddEvent(11, ShowPlayerUIMessage);   // 11: keyDown -> show message
        AddEvent(12, ShowPlayerUIMessage);   // 12: keyDown -> show message
        AddEvent(13, ShowPlayerUIMessage);   // 13: keyDown -> show message
        AddEvent(14, TransitionToNextScene);   // 14: keyDown -> change scene
    }
}
