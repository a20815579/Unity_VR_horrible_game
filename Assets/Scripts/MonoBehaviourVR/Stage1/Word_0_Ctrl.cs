using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Word_0_Ctrl : MonoBehaviour
{
    private InputActions inputActions;
    [SerializeField]
    int _id;

    public GameObject wordImg;
    public ItemGazeDetect gazeDetect;

    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
        this.enabled = false;
    }
    

    private void Update()
    {
        if (gazeDetect && gazeDetect.IsGazingUpon)
        {
            Appear();
        }
    }
    public void Appear()
    {
        Debug.Log("Word Appear");
        wordImg.GetComponent<Animation>().Play("FadeIn");
        inputActions.ResponseOnInput();

        this.enabled = false;
    }
    
}
