using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallFallsInWater : MonoBehaviour
{
    bool isFalling = false;
    [SerializeField]
    Stage_8_Manager stage_8_Manager;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name != "Rectangle073" 
            && !isFalling) {
            isFalling = true;
            
            stage_8_Manager.PlaySFX();
            StartCoroutine(DelayThenPlaySFX());
        }
    }

    IEnumerator DelayThenPlaySFX() {
        yield return new WaitForSeconds(1.0f);
        stage_8_Manager.PlaySFX();
    }
}
