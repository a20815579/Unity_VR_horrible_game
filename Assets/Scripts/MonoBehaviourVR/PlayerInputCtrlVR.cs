using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCtrlVR : MonoBehaviour
{
    InputActions[] inputActions;
    [SerializeField]
    int[] action_idx;
    [SerializeField]
    static int current_idx;

    private void Start()
    {
        current_idx = 0;
        // create instance of ScriptableObject
        inputActions = new InputActions[action_idx.Length];
        for (int i = 0; i < action_idx.Length; i++)
        {
            inputActions[i] = ScriptableObject.CreateInstance<InputActions>();
            inputActions[i].id = action_idx[i];
        }
        CheckEventIdx(0);
    }
    private void OnEnable()
    {
        GameManager.instance.gameObject.GetComponent<StageManager>().OnEventIdxChanged += CheckEventIdx;
    }

    private void OnDisable()
    {
        if (GameManager.instance)
        {
            GameManager.instance.gameObject.GetComponent<StageManager>().OnEventIdxChanged -= CheckEventIdx;
        }
    }
    public void CheckEventIdx(int idx)
    {
        GetComponent<BoxCollider>().enabled = (idx == action_idx[current_idx]);
        
    }

    public void NextLine()
    {
        if (inputActions[current_idx].ResponseOnInput())
        {
            current_idx++;
        }
    }
}
