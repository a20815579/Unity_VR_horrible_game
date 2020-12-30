using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenArmCtrl : MonoBehaviour
{
    public void Wave()
    {
        GetComponent<Animator>().SetTrigger("Wave");

    }
    public void OpenArm()
    {
        GetComponent<Animator>().SetTrigger("Hug");
    }
}
