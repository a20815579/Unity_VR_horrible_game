using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* sample code for monobehaviour */
public class TouchedControllerVR : MonoBehaviour
{
    protected InputActions inputActions;
    [SerializeField]
    int _id;
    [SerializeField]
    int current_idx;

    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    // trigger
    public virtual void ResponseOnInput()
    {
        inputActions.ResponseOnInput();
    }
}
