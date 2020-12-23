using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary_close_controller : MonoBehaviour
{
    public GameObject diary_open;
    public void ChangeToOpen()
    {
        diary_open.SetActive(true);
        Destroy(gameObject);
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
