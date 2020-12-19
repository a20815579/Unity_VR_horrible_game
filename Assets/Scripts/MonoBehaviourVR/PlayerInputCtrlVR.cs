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
    }
    private void Update()
    {
        if ((OVRInput.GetDown(OVRInput.RawButton.A))) {
            Debug.Log("x button down");
            if (inputActions[current_idx].ResponseOnInput())
            {
                current_idx++;
            }
        }
    }
}
