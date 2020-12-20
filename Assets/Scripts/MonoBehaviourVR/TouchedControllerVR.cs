using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* sample code for monobehaviour */
public class TouchedControllerVR : MonoBehaviour
{
    private InputActions inputActions;
    [SerializeField]
    int _id;
    [SerializeField]
    GameObject centerEye;
    [SerializeField]
    GameObject rightHand;

    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    // trigger
    public void ResponseOnInput()
    {
        Debug.Log("ResponseOnInput");
        inputActions.ResponseOnInput();
    }
}
