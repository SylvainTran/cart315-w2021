using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using TMPro;
public class WalkToIntimateMoment : MonoBehaviour
{
    private NavMeshAgent nav;
    public Transform destination;
    public Transform destinationBack;
    private Animator animator;
    public GameObject closeupCam;
    public GameObject playerCloseUpCam;
    public GameObject DialogueCanvas;
    private Transform DialogueCanvasTextUI;
    private Transform DialogueCanvasQTETutorial;
    public GameObject DialogueCanvasQTE;    
    private bool startedCutscene = false;
    private bool QTE_Ended = false;
    private bool QTE_Step_1_Ended = false;
    private bool allowFlicker = true;
    private AudioSource music;
    public GameObject initializer;
    private GameObject player;
    public GameObject creepInCorner;    
    public GameObject[] influencedStoryActors;
    public GameObject beerCrateObstacle;
    public GameObject CheckpointSound;
    public AudioClip checkpointSound;
    public void Start() {
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        DialogueCanvas = GameObject.FindGameObjectWithTag("DialogueCanvas");
        DialogueCanvasTextUI = DialogueCanvas.transform.Find("DialogueCanvasTextUI_Lyrics");
        music = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        initializer = GameObject.FindGameObjectWithTag("Initializer");
        // Go to destination for intimate moment cutscene
        EnactPerformance();
    }

    public void StartDialogueCutscene() {
        if(startedCutscene) return;
        string[] dialogues = GetComponent<DialogueNode>().text;
        int len = dialogues.Length;
        string text = GetComponent<DialogueNode>().speakers[0] + ": ";
        for (int i = 0; i < len; i++)
        {
            text += dialogues[i] + "\n";
        }        
        DialogueCanvasTextUI.gameObject.GetComponent<TextMeshProUGUI>().SetText(text);
        if(initializer.GetComponent<AudioSource>().isPlaying || initializer.GetComponent<AudioSource>().volume > 0) {
            initializer.GetComponent<AudioSource>().Stop();
            initializer.GetComponent<AudioSource>().volume = 0;
        }
        music.Play();
        music.loop = true;

        // QTE relationship possible while music is playing
        Invoke("EndCutscene", 7.0f);
    }

    public void EnactPerformance() {
        nav.SetDestination(destination.position);
    }

    public void WaitAndFlicker() {
        // Flicker
        float rand = Random.Range(0.0f, 1.0f);
        if(rand < 0.5f) {
            FlickerBetweenCams(closeupCam, playerCloseUpCam);
        } else {
            FlickerBetweenCams(playerCloseUpCam, closeupCam);
        }
    }

    public void FlickerBetweenCams(GameObject cam1, GameObject cam2) {
        cam1.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        cam2.GetComponent<CinemachineVirtualCamera>().Priority = 100;
    }

    public void DestroyCreepers() {
        Destroy(this.gameObject);
        Destroy(creepInCorner.gameObject);
    }

    void Update() {
        float dist = nav.remainingDistance;
        if(nav.remainingDistance != 0) {
            animator.SetBool("isWalking", true);
        }
        else if(!startedCutscene) {
            animator.SetBool("isWalking", false);
            // Rotate towards player
            // Zoom on face
            closeupCam.GetComponent<CinemachineVirtualCamera>().Priority = 100;
            StartDialogueCutscene();
            startedCutscene = true;
        }   
        // If during performance, flicker between cams
        // if(allowFlicker && startedCutscene && music.isPlaying) {
        //     InvokeRepeating("WaitAndFlicker", 4.0f, 4.0f);
        // }
        // If music ended, end cutscene
        if(startedCutscene && QTE_Ended) {
            closeupCam.GetComponent<CinemachineVirtualCamera>().Priority = 0;
            player.GetComponent<PlayerController>().cutSceneEnded = true;
            player.GetComponent<PlayerController>().canMove = true;
            DialogueCanvasTextUI.gameObject.GetComponent<TextMeshProUGUI>().SetText("");   
            // Stop flicker
            // allowFlicker = false;
            // CancelInvoke();         
            // Walk npc back and make it inactive
            nav.SetDestination(destinationBack.position);
            if(nav.remainingDistance < 0.01f) {
                animator.SetBool("isWalking", false);
                Invoke("DestroyCreepers", 5.0f);
                // Update story states (dialogue active nodes for relevant actors)
                for(int i = 0; i < influencedStoryActors.Length; i++) {
                    influencedStoryActors[i].GetComponentInChildren<DialogueNode>().activeDialogueNode = 1;
                }
            }
            // Update storystate
            CheckpointSound.GetComponent<AudioSource>().PlayOneShot(checkpointSound);
            StoryState.SnowCutscene = true;
            Destroy(beerCrateObstacle.gameObject);
            initializer.GetComponent<AudioSource>().Play();
            initializer.GetComponent<AudioSource>().loop = true;
            initializer.GetComponent<AudioSource>().volume = 100;
        } else if(startedCutscene && !QTE_Ended) {
            // Handle QTE via mouse buttons

        }
    }

    public void EndCutscene() {
        QTE_Ended = true;
    }
    public void HandleQTE() {
        QTE_Step_1_Ended = true;
        QTE_Ended = true;
    }
}
