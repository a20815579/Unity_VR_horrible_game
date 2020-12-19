using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHintCtrl : MonoBehaviour
{
    public GameObject HintUI;
    public void ShowHint(bool show)
    {
        HintUI.SetActive(show);
    }
}
