using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* sample code for monobehaviour */
public class TouchedControllerVRMulti : MonoBehaviour
{
    protected InputActions[] inputActions;
    [SerializeField]
    int[] action_idx;
    [SerializeField]
    int current_idx;

    void Start()
    {
        // create instance of ScriptableObject
        inputActions = new InputActions[action_idx.Length];
        for (int i = 0; i < action_idx.Length; i++)
        {
            inputActions[i] = ScriptableObject.CreateInstance<InputActions>();
            inputActions[i].id = action_idx[i];
        }
    }
    // trigger
    public virtual void ResponseOnInput()
    {
        if (inputActions[current_idx].ResponseOnInput()) {
            current_idx++;
        }
    }
}
