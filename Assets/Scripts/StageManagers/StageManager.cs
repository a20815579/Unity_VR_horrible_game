using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    /* put gameobject here */
    //private GameObject xxx;
    [SerializeField]
    protected int currentId = 0;
    [SerializeField]
    protected List<Action> ResponseToInput = new List<Action>();
    [SerializeField]
    protected int totalEventSize; //assign the event size in Inspector
   
    public bool LoadWithChapter = true;

    public event Action<int> OnEventIdxChanged;
    //For hint
    //private int interactionObj_Id = 0;
    //public BoxCollider[] objectColliders;
    
    public void CreateEventList()
    {
        if (totalEventSize == 0)
        {
            Debug.LogError("Event size is not assigned!");
            return;
        }
        for (int i=0; i<totalEventSize; i++)
        {
            ResponseToInput.Add(BlankFunc);
        }
        Debug.Log(ResponseToInput.Count);
    }
    private void BlankFunc()
    {

    }
    protected void AddEvent(int idx, Action func)
    {
        if (idx >= totalEventSize)
        {
            Debug.LogError("Failed to AddEvent! Event Index out of bound.");
            return;
        }
        ResponseToInput[idx] = func;
    }
    
    public virtual void SetupEvents()
    {
        
        /* add event-triggered functions to delegate list */
        AddEvent(0, ShowPlayerUIMessage); //0:show message(default)
        AddEvent(1, HidePlayerUIMessage); //1:keyDown -> hide message -> wait for click window
        AddEvent(2, ShowPlayerUIMessage); //2:click window -> show message
        AddEvent(3, ShowPlayerUIMessage); //3:keyDown -> show message
        AddEvent(4, ShowPlayerUIMessage); //4:keyDown -> show message
        AddEvent(5, HidePlayerUIMessage); //5:keyDown -> hide message
        AddEvent(6, TransitionToNextScene); //6:click monitor -> next scene

        //ReactOnInput(0); //uncomment this line if first event needs to start defaultly
    }
    
    public bool ReactOnInput(int id)
    {
        if (id == currentId)
        {
            Debug.Log($"Invoke Event {id}");
            ResponseToInput[id].Invoke();
            currentId++;

            OnEventIdxChanged?.Invoke(currentId);
            return true;
        }

        return false;
    }

    /* store all of the event-triggered functions here */
    protected void TransitionToNextScene()
    {
        GameManager.instance.TransitionToNextScene();
    }

    protected void ShowPlayerUIMessage()
    {
        PlayerUI_TextCtrl.self.ShowText();
    }
    protected void HidePlayerUIMessage()
    {
        PlayerUI_TextCtrl.self.HideText();
    }

    protected void ShowItemImage()
    {
        ItemImageUICtrl.self.ShowItemImage();
    }

    protected void HideItemImage()
    {
        Debug.Log("hide Item Image");
        ItemImageUICtrl.self.HideItemImage();
    }

    protected void DelayThenDoNext(float sec)
    {
        StartCoroutine(NextDelay(sec));
    }
    protected void Delay(float sec)
    {
        StartCoroutine(SimpleDelay(sec));
    }

    IEnumerator NextDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        ReactOnInput(currentId);
    }

    IEnumerator SimpleDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
    /*
    private void ShowHint()
    {
        objectColliders[interactionObj_Id].GetComponent<ShowHintCtrl>().ShowHint(true);
    }

    private void EnableObjectInteraction()
    {
        objectColliders[interactionObj_Id].enabled = true;
    }*/

}
