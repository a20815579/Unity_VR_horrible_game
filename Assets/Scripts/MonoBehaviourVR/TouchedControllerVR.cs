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
    AudioSource audioSource;

    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    // trigger
    public void ResponseOnInput()
    {
        Debug.Log("ResponseOnInput");
        audioSource.Play();
        inputActions.ResponseOnInput();
    }
}
