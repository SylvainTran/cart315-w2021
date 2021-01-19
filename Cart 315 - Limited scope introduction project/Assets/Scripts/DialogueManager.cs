using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;
public class DialogueManager : MonoBehaviour, IPointerDownHandler
{
    public GameObject dialogueCanvas;
    public string area;
    public int[] node;
    public string[] text;
    public string[] speakers;
    public GameObject player;
    public GameObject dialogueNode;
    public GameObject snowCam;
    private GameObject instanceSnowCam;
    public GameObject creeperFaceCam;

    void Start() {
        instanceSnowCam = Instantiate(snowCam);
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(player.GetComponent<PlayerController>().interactingWith) {
            // Get the text
            dialogueNode = player.GetComponent<PlayerController>().interactingWith.gameObject;
            text = dialogueNode.GetComponent<DialogueNode>().text;
        }
        // If there is another dialogue node following the active one, show active dialogue node to it and display text
        if(text.Length > 0) {
            // Pop first element
            dialogueNode.GetComponent<DialogueNode>().activeDialogueNode++;
            if( dialogueNode.GetComponent<DialogueNode>().activeDialogueNode > text.Length - 1) {
                // Clamp
                 dialogueNode.GetComponent<DialogueNode>().activeDialogueNode = 0;
            }
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.transform.parent.gameObject);
    }

    public void WatchSnowFallTogether() {
        Debug.Log("Watching snow fall together with Dicky.");
        creeperFaceCam.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        instanceSnowCam.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 100;
    }

    public void AskAboutTheTruth() {
        Debug.Log("Asked Dicky about the truth.");
    }
}
