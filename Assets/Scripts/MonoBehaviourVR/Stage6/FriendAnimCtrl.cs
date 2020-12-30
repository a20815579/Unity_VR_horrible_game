using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendAnimCtrl : MonoBehaviour
{
    Animator anim;
    public GameObject OriginalHeadObj, DropHeadObj;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Clap(bool clap)
    {
        anim.SetBool("isClapping", clap);
    }

    public void DropHead()
    {
        anim.speed = 0;
        OriginalHeadObj.SetActive(false);
        DropHeadObj.SetActive(true);
        DropHeadObj.GetComponent<Rigidbody>().AddTorque(Vector3.forward);
    }
}
