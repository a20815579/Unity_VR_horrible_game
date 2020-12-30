using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchCtrl : MonoBehaviour
{
    protected InputActions[] inputActions = new InputActions[2];
    [SerializeField]
    int[] _id;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
