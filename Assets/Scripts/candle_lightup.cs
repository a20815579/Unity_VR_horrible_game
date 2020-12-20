using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle_lightup : MonoBehaviour
{
    public Light mylight;
    public void candle_lightup_func()
    {
        mylight.enabled = true;
        Debug.Log("light");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("light_unable");
        mylight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
