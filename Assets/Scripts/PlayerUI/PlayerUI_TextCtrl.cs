using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerUI_TextCtrl : MonoBehaviour
{
    public static PlayerUI_TextCtrl self;
    Text text;
    [SerializeField]
    Image BG;

    [SerializeField]
    private string[] messages;
    [SerializeField]
    private Message[] message;

    private int message_idx = -1;

    private InputActions inputActions;
    [Serializable]
    struct Message {
        public string messageText;
        public MessageType messageType;
    }
    enum MessageType
    {
        OS, SELF, OTHER
    }
    private void Awake()
    {
        self = this;
        text = GetComponent<Text>();
        Debug.Log(name);
    }
    
    public void ShowText()
    {
        text.enabled = true;
        BG.enabled = true;
        message_idx++;
        if (message_idx < messages.Length)
        {
            text.text = messages[message_idx];
            text.text = message[message_idx].messageText;
            if (message[message_idx].messageType != MessageType.OTHER)
            {
                text.fontStyle = FontStyle.Italic;
                if (message[message_idx].messageType == MessageType.OS)
                {
                    text.text = $"({text.text})";
                }
            }
            else
            {
                text.fontStyle = FontStyle.Normal;
            }
        }
        
    }
    public void HideText()
    {
        text.enabled = false;
        BG.enabled = false;
    }
}
