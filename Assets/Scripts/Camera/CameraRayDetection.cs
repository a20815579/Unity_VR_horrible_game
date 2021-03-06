using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayDetection : MonoBehaviour
{
    public Camera viewCamera;
    [SerializeField]
    private GameObject lastGazedUpon;
    void Update()
    {
        CheckGaze();
    }
    private void CheckGaze()
    {
        //Debug.Log(lastGazedUpon);
        if (lastGazedUpon)
        {
            lastGazedUpon.SendMessage("NotGazingUpon", SendMessageOptions.DontRequireReceiver);
        }
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity))
        {
            hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
            lastGazedUpon = hit.transform.gameObject;
        }

    }
}
