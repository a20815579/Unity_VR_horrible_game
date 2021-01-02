using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallFallsInWater : MonoBehaviour
{
    bool isFalling = false;
    [SerializeField]
    Stage_8_Manager stage_8_Manager;
    AudioSource audioSource;
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
        audioSource = stage_8_Manager.Effect_player;
        StartCoroutine(GraduallyDecreaseSFX());
    }

    IEnumerator GraduallyDecreaseSFX() {
        float factor = 0.1f;

        const int V = 10;
        for (int i = 0; i < V; i++) {
            audioSource.volume -= factor;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
