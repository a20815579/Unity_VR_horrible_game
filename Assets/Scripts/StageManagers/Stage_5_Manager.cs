using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_5_Manager : StageManager
{
    public FoIn_vanish[] foIn_Vanish;
    // Start is called before the first frame update
    public override void SetupEvents()
    {

        /* add event-triggered functions to delegate list */
        AddEvent(0, FoInVanish1); //click foIn -> Vanish
        AddEvent(1, FoInVanish2); //click foIn -> Vanish
        
    }
    void FoInVanish1()
    {
        foIn_Vanish[0].Vanish();
    }
    void FoInVanish2()
    {
        foIn_Vanish[1].Vanish();
    }
}
