using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Stage Manager
    StageManager stageManager;

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

            // Find the active singleton already created
            _instance = FindObjectOfType<GameManager>();
            if (_instance != null)
            {
                return _instance;
            }

            // create singleton
            GameObject obj = new GameObject();
            obj.name = "GameManager";
            _instance = obj.AddComponent<GameManager>();
            return _instance;
        }
    }
    

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        //Debug.Log("Get Stage Managers");
        stageManager = GetComponent<StageManager>();
    }
    void Start()
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
