using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* sample code for monobehaviour */
public class TouchedControllerVR : MonoBehaviour
{
    protected InputActions inputActions;
    [SerializeField]
    int _id;

    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    // trigger
    protected virtual void ResponseOnInput()
    {
        inputActions.ResponseOnInput();
    }
}
