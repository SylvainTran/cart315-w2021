using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;

    public void Awake()
    {
        dialogueCanvas = GameObject.Instantiate(Resources.Load("DialogueCanvas")) as GameObject;
        GameObject.DontDestroyOnLoad(dialogueCanvas);

    }
}
