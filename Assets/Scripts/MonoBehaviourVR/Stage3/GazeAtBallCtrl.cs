using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeAtBallCtrl : MonoBehaviour
{
    private InputActions inputActions;
    [SerializeField]
    int _id;
    public ItemGazeDetect gazeDetect;
    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }
    private void Update()
    {
        if (gazeDetect && gazeDetect.IsGazingUpon)
        {
            inputActions.ResponseOnInput();
            Debug.Log("Gaze");
            this.enabled = false;
        }
    }
}
