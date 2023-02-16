using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    private Queue<string> lines;

    void start()
    {
        lines = new Queue<string>();
    }
    public void ActivateTutorial(Dialogue text)
    {
        UnityEngine.Debug.Log("This is the " + text.name);
    }
}

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 9)]
    public string[] sentences;
}