using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenesCtrl : MonoBehaviour
{
    public static LoadingScenesCtrl self;
    private void Awake()
    {
        self = this;
    }
    private void Start()
    {
        GetComponent<Animator>().SetBool("WithChapter", GameManager.instance.GetLoadWithChapter());
    }
    public void SceneFinishedLoading()
    {
        GameManager.instance.StageStart();
    }
    public void TransitionToNextScene()
    {
        Debug.Log("NextScene");
        GetComponent<Animator>().Play("SceneFadeOut");
    }
    public void Go()
    {
        Debug.Log("Go");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
