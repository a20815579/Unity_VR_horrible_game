﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle_lightup : MonoBehaviour
{
    public void candle_lightup_func()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
