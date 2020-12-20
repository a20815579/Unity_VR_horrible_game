using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI_TextCtrl : MonoBehaviour
{
    public static PlayerUI_TextCtrl self;
    Text text;

    [SerializeField]
    private string[] messages;

    private int message_idx = -1;

    private InputActions inputActions;

    private void Awake()
    {
        self = this;
        text = GetComponent<Text>();
    }
    
    public void ShowText()
    {
        text.enabled = true;
        message_idx++;
        if (message_idx < messages.Length)
        {
            text.text = messages[message_idx];
        }
    }
    public void HideText()
    {
        text.text = "";
        text.enabled = false;

    }
}
