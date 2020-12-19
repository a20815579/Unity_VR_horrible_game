using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* sample code for monobehaviour */
public class TouchedController : MonoBehaviour
{
    private InputActions inputActions;
    [SerializeField]
    int _id;
    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    // trigger
    void OnMouseDown()
    {
        inputActions.ResponseOnInput();
    }
}
