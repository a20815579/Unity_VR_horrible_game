using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActions : ScriptableObject
{
    public int id;
    public bool ResponseOnInput() {
        return GameManager.instance.ReactOnInput(id);
    }
}