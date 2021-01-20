using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
    public string area;
    public int[] node;
    public string[] text;
    public string[] text2;
    public string[] speakers;
    public int activeDialogueNode = 0;

    void OnEnable() {
        BeerCrate.OnStoryAction += UpdateDialogueNode;
    }

    void OnDisable() {
        BeerCrate.OnStoryAction -= UpdateDialogueNode;
    }

    void Update() {
        if(Input.anyKeyDown) {
            RaycastHit hit;
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            Physics.Raycast(ray.origin, ray.direction * 10, out hit, Mathf.Infinity);
            if(hit.collider != null) {
                // Debug.DrawLine(ray.origin, hit.point);
                // Debug.Log("Clicked on screen or pushed a button.");
                // Debug.Log(hit.collider.gameObject.name);
            }
        }
        UpdateDialogueNode();
    }

    public void UpdateDialogueNode() {
        // Debug.Log("StoryState Took beer crate: " + StoryState.TookBeerCrate);
        // Debug.Log("StoryState Helped barman: " + StoryState.HelpedBarman);
        if(StoryState.TookBeerCrate && StoryState.HelpedBarman) {
            text = text2;
        }
    }
}
