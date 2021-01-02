using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFalls : MonoBehaviour {
    AudioSource audio;
    bool isFalled = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (!isFalled) {
            audio.Play();
            isFalled = true;
        }
    }

}