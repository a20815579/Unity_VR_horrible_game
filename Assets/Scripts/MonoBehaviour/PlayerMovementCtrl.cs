using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCtrl : MonoBehaviour
{
    private float speed = 5f;
    
    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.forward * speed;
        }
    }
}
