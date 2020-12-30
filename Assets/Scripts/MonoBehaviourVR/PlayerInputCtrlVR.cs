using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCtrlVR : MonoBehaviour
{
    InputActions[] inputActions;
    [SerializeField]
    int[] action_idx;
    [SerializeField]
    int current_idx;
    public Collider[] colliders;
    private void Awake()
    {
        current_idx = -1;
        // create instance of ScriptableObject
        inputActions = new InputActions[action_idx.Length];
        for (int i = 0; i < action_idx.Length; i++)
        {
            inputActions[i] = ScriptableObject.CreateInstance<InputActions>();
            inputActions[i].id = action_idx[i];
        }
    }
    private void Start()
    {
        
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
        if (current_idx + 1 >= action_idx.Length)
        {
            if (GameManager.instance)
            {
                GameManager.instance.gameObject.GetComponent<StageManager>().OnEventIdxChanged -= CheckEventIdx;
            }
            colliders[1].enabled = colliders[0].enabled = false;

            return;
        }
        Debug.Log($"GM:{idx} | INPUT:{action_idx[current_idx + 1]}");

        if (idx == action_idx[current_idx + 1])
        {
            colliders[1].enabled = colliders[0].enabled = true;
            current_idx++;
            
        }
        else
        {
            colliders[1].enabled = colliders[0].enabled = false;

        }
    }

    public void NextLine()
    {
        inputActions[current_idx].ResponseOnInput();
    }
}
