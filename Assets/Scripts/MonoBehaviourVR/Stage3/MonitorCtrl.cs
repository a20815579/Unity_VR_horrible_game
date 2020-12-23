using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCtrl : MonoBehaviour
{
    protected InputActions[] inputActions = new InputActions[2];
    [SerializeField]
    int[] _id;
    public SpriteRenderer code;

    void Awake()
    {
        for (int i = 0; i < inputActions.Length; i++)
        {// create instance of ScriptableObject
            inputActions[i] = ScriptableObject.CreateInstance<InputActions>();
            inputActions[i].id = _id[i];
        }
    }

    // trigger
    public void ResponseOnInput()
    {
        for (int i = 0; i < inputActions.Length; i++)
        {
            inputActions[i].ResponseOnInput();
        }
    }

    public void ShowCode(bool show)
    {
        code.enabled = show;
    }
    
}
