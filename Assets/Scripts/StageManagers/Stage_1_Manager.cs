using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage_1_Manager : StageManager
{
    public override void SetupEvents()
    {
        Debug.Log("Stage 1 event setup");
        
        /* add event-triggered functions to delegate list */
        AddEvent(0, HidePlayerUIMessage); //keyDown -> hide message -> wait for click window
        AddEvent(1, ShowPlayerUIMessage); //click window -> show message
        AddEvent(2, ShowPlayerUIMessage); //keyDown -> show message
        AddEvent(3, ShowPlayerUIMessage); //keyDown -> show message
        AddEvent(4, HidePlayerUIMessage); //keyDown -> hide message
        AddEvent(5, TransitionToNextScene); //click door -> next scene

        //ReactOnInput(0); //uncomment this line if first event needs to start defaultly
    }

    private void CustomFunction()
    {
        //do something
    }
}
