using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
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

        AddEvent(0, ShowPlayerUIMessage);   // 0: show message
        AddEvent(1, HidePlayerUIMessage);   // 1: keyDown -> hide message
        AddEvent(2, ShowPlayerUIMessage);   // 2: select on exam paper -> hide message
        AddEvent(3, HidePlayerUIMessage);   // 3: keyDown -> show message
        AddEvent(4, ShowPlayerUIMessage);   // 4: select on computer monitor -> show message
        AddEvent(5, HidePlayerUIMessage);   // 5: keyDown -> hide message
        AddEvent(6, ShowPlayerUIMessage);   // 6: keyDown on wine bottle -> show message
        AddEvent(7, ShowPlayerUIMessage);   // 7: keyDown -> show message
        AddEvent(8, ShowPlayerUIMessage);   // 8: keyDown -> show message
        AddEvent(9, ShowPlayerUIMessage);   // 9: keyDown -> show message
        AddEvent(10, TransitionToNextScene);   // 10: keyDown -> transition to next scene

        ReactOnInput(0);
    }
}
