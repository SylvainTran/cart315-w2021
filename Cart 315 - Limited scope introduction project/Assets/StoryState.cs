using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryState : MonoBehaviour
{
    public static bool SnowCutscene = false;
    public static bool TookBeerCrate = false;
    public static bool HelpedBarman = false;

    void OnEnable() {
        BeerCrate.OnStoryAction += UpdateStoryState;
    }

    void OnDisable() {
        BeerCrate.OnStoryAction -= UpdateStoryState;
    }

    void UpdateStoryState() {
        TookBeerCrate = true;
    }
}
