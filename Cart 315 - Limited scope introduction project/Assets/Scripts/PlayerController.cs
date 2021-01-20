using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform cam;
    float acceleration = 1.5f;
    public float turnSmooth = 0.3f;
    public float turnSmoothVelocity;
    public Boolean canMove = true;
    public Transform intimateCutScenePlayerSpot;
    public GameObject creeperIntimateCutSceneActor;
    private Animator animator;
    private AudioSource audio;
    public GameObject BarOverviewCam;
    public GameObject FriendsTableCam;
    public GameObject BartenderCam;
    public GameObject CreepCornerCam;
    public GameObject DarrylTableCam;
    public GameObject NeganTableCam;
    public GameObject OutsideBarAreaCam;
    public GameObject EdgeOfCreationCam;
    public GameObject DialogueCanvas;
    private Transform DialogueCanvasTextUI;
    public TextAsset jsonFile;
    public string jsonPath;
    public bool cutSceneEnded = false;
    public AudioClip gibberish;
    public GameObject interactingWith;

    [Serializable]
    public class DialogueNodes
    {
        public string[] level;
        public static DialogueNodes CreateFromJSON(string jsonString) {
            Debug.Log(jsonString);
            return JsonUtility.FromJson<DialogueNodes>(jsonString);
        }

        public override string ToString(){
            string result = "Dialogue Nodes:\n";
            // DialogueNode d = new DialogueNode();
            for(int i = 0; i < level.Length; i++) {
                Debug.Log(level[i]);
            }
            return result;
        }        
    }

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        DialogueCanvas = GameObject.FindGameObjectWithTag("DialogueCanvas");
        DialogueCanvasTextUI = DialogueCanvas.gameObject.transform.Find("DialogueCanvasTextUI");
        // Play audio
        if(!audio.isPlaying) {
            audio.PlayDelayed(0.3f);
        }
    }

    void SwitchVirtualCameras(GameObject oldCam, GameObject newCam) {
        // if(!cutSceneEnded) return;
        oldCam.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        newCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Untagged")) {
            return;
        }
        else if(other.gameObject.CompareTag("FriendsTable"))
        {
            SwitchVirtualCameras(BarOverviewCam, FriendsTableCam);
            StartDialogue(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BartenderCam")) {
            SwitchVirtualCameras(BarOverviewCam, BartenderCam);            
            StartDialogue(other.gameObject);
        }
        else if (other.gameObject.CompareTag("CreepCorner")) {
            SwitchVirtualCameras(BarOverviewCam, CreepCornerCam);            
            StartDialogue(other.gameObject);
        }
        else if (other.gameObject.CompareTag("DarrylTable")) {
            if(StoryState.HelpedBarman) {
               SwitchVirtualCameras(BarOverviewCam, DarrylTableCam);            
            }
            StartDialogue(other.gameObject);
        }
        else if (other.gameObject.CompareTag("NeganTable")) {
         if(StoryState.HelpedBarman) {
            SwitchVirtualCameras(BarOverviewCam, NeganTableCam);            
         }          
            StartDialogue(other.gameObject);
        }        
        else if (other.gameObject.CompareTag("OutsideBarAreaCam")) {
            SwitchVirtualCameras(BarOverviewCam, OutsideBarAreaCam);            
        }
        else if (!cutSceneEnded && other.gameObject.CompareTag("EdgeOfCreation")) {
            SwitchVirtualCameras(BarOverviewCam, EdgeOfCreationCam);   
            // Start cinematic with creepy guy
            canMove = false;
            // Place player at right spot
            Vector3 pos = intimateCutScenePlayerSpot.position + new Vector3(0, 0, -4f);
            transform.position = pos;
            creeperIntimateCutSceneActor.SetActive(true);
        }        
    }

    private void StartDialogue(GameObject other)
    {
        // Update public interactingWith variable for the dialogue manager
        interactingWith = other;
        string[] dialogues = other.GetComponent<DialogueNode>().text;
        int len = dialogues.Length;
        string text = other.GetComponent<DialogueNode>().speakers[0] + ": ";
        // for (int i = 0; i < len; i++)
        // {
        //     text += dialogues[i] + "\n";
        // }
        text += dialogues[other.GetComponent<DialogueNode>().activeDialogueNode];
        DialogueCanvasTextUI.gameObject.GetComponent<TextMeshProUGUI>().SetText(text);
        // Play gibberish sound
        // if(!other.gameObject.GetComponent<AudioSource>().isPlaying) {
        //     other.gameObject.GetComponent<AudioSource>().PlayOneShot(gibberish, 0.9f);
        // }
    }

    void OnTriggerExit(Collider other) {
        // Clear last dialogue
        DialogueCanvasTextUI.gameObject.GetComponent<TextMeshProUGUI>().SetText("");
        if(other.gameObject.CompareTag("FriendsTable")) {
            // Reset dialogue state
            other.GetComponent<DialogueNode>().activeDialogueNode = 0;
            SwitchVirtualCameras(FriendsTableCam, BarOverviewCam);              
        }   
        else if(other.gameObject.CompareTag("BartenderCam")) {
            SwitchVirtualCameras(BartenderCam, BarOverviewCam);              
        }
        else if (other.gameObject.CompareTag("CreepCorner")) {
            SwitchVirtualCameras(CreepCornerCam, BarOverviewCam);              
        }
        else if (other.gameObject.CompareTag("DarrylTable")) {
            SwitchVirtualCameras(DarrylTableCam, BarOverviewCam);            
        }
        else if (other.gameObject.CompareTag("NeganTable")) {
            SwitchVirtualCameras(NeganTableCam, BarOverviewCam);            
        }              
        else if (other.gameObject.CompareTag("OutsideBarAreaCam")) {
            SwitchVirtualCameras(OutsideBarAreaCam, BarOverviewCam);              
        }        
        else if (other.gameObject.CompareTag("EdgeOfCreation")) {
            SwitchVirtualCameras(EdgeOfCreationCam, BarOverviewCam);                          
        }        
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 directionVector = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        float sqrMag = directionVector.sqrMagnitude;
        if (sqrMag >= 0.1f && canMove)
        {
            // Animate
            animator.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(directionVector.x, directionVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        }
        // Animate
        animator.SetBool("isWalking", true);
        if(sqrMag <= 0.0f) {
            animator.SetBool("isWalking", false);
        }
    }
}