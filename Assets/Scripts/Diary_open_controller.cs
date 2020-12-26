using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary_open_controller : MonoBehaviour
{
    public void NextPage()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(true);
    }
    public void NextPageAgain()
    {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(7).gameObject.SetActive(false);
    }
    public void BloodMsg()
    {
        transform.GetChild(3).gameObject.GetComponent<Animation>().enabled = true;
        transform.GetChild(4).gameObject.SetActive(true);        
    }
    public void BloodMsg2()
    {
        transform.GetChild(8).gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
