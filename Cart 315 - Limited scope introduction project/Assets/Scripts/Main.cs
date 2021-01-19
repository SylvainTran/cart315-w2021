using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Loads important variables
public sealed class Main : MonoBehaviour
{
    // Beer plants currently in existence
    public int activeBeerPlantsCount = 0;

    void Start() {
        // if(!GetComponent<AudioSource>().isPlaying) {
        //     GetComponent<AudioSource>().Play();
        //     GetComponent<AudioSource>().loop = true;
        // }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadMain()
    {
        GameObject main = GameObject.Instantiate(Resources.Load("Initializer")) as GameObject;
        GameObject.DontDestroyOnLoad(main);
        Debug.Log("Loaded initializer");
        // GameObject dialogueManager = GameObject.Instantiate(Resources.Load("DialogueManager")) as GameObject;
        // GameObject.DontDestroyOnLoad(dialogueManager);
    }
}

// Reference:
//https://low-scope.com/unity-tips-1-dont-use-your-first-scene-for-global-script-initialization/