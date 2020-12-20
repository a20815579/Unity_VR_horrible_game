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
    public void SceneFinishedLoading()
    {
        GameManager.instance.StageStart();
    }
    public void TransitionToNextScene()
    {
        Debug.Log("NextScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
