using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Stage Manager
    StageManager stageManager;
    static bool created;
    /* singleton */
    private static GameManager _instance;
   
    public static GameManager instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                return null;
            }
        }
    }
    

    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(gameObject);
        //Debug.Log("Get Stage Managers");
        stageManager = GetComponent<StageManager>();
        if (LoadingScenesCtrl.self)
        {
            LoadingScenesCtrl.self.GetComponent<Animator>().SetBool("WithChapter", stageManager.LoadWithChapter);
        }
        else
        {
            StageStart();
        }
    }
    

    public void StageStart()
    {
        //Debug.Log("Start");
        stageManager.CreateEventList();
        stageManager.SetupEvents();
    }

    public bool ReactOnInput(int id)
    {
        return stageManager.ReactOnInput(id);
    }

    public void TransitionToNextScene()
    {
        Debug.Log("NextScene");
        if (LoadingScenesCtrl.self)
        {
            LoadingScenesCtrl.self.TransitionToNextScene();
        }
    }
}
