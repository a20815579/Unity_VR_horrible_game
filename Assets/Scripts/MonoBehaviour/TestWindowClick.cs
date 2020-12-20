using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWindowClick : MonoBehaviour
{
    private InputActions inputActions;
    [SerializeField]
    int _id;
    void Start()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    // trigger
    void OnMouseDown()
    {
        if (inputActions.ResponseOnInput())
        {
            Debug.Log("mouseDown");
        }
    }
}
