using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoolCollision : MonoBehaviour
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

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == "ball") {
            inputActions.ResponseOnInput();
        }
    }
}