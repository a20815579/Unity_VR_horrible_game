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
    GameObject centerEye;
    [SerializeField]
    GameObject rightHand;

    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }

    // trigger
<<<<<<< Updated upstream
    void Update()
=======
    public void ResponseOnInput()
>>>>>>> Stashed changes
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A)) {
            RaycastHit hit;
            //Transform centerEye = OVRCameraRig.centerEyeAnchor();
            //Transform rightHand = OVRCameraRig.rightHandAnchor();
            Vector3 direction = 
                rightHand.transform.position - centerEye.transform.position;
            if (Physics.Raycast(centerEye.transform.position, direction, out hit)) {
                if (hit.transform.gameObject == gameObject) {
                    Debug.Log("Raycast hit!");
                    inputActions.ResponseOnInput();
                }
            }
        }    
    }
}
