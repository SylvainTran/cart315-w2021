using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerCrate : MonoBehaviour
{
    public Transform itemHoldPosition;
    public delegate void StoryAction();
    public static event StoryAction OnStoryAction;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            if(OnStoryAction != null && StoryState.SnowCutscene && !StoryState.HelpedBarman) {
                this.transform.parent = itemHoldPosition;
                StoryState.TookBeerCrate = true;
                OnStoryAction();
            }
        }    
    }

    // void Update() {
    //     if(StoryState.HelpedBarman == true) {
    //         OnStoryAction();
    //     }
    // }
}
