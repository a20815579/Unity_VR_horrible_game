using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManCtrl : MonoBehaviour
{
    public void Fall()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
