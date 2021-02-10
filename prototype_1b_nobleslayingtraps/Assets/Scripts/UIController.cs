using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject TRAP_COUNTER_DISPLAY;
    public GameObject FAME_SCORE_DISPLAY;
    public GameObject HOUSE_SINKING_RATE_DISPLAY;

    void OnEnable()
    {
        BuyTraps.UIOnBuyClaymoreTrap += UpdateTrapCounterDisplay;
        PlaceTrap.UIOnPlacedClaymoreTrap += UpdateTrapCounterDisplay;
    }

    void OnDisable()
    {
        BuyTraps.UIOnBuyClaymoreTrap -= UpdateTrapCounterDisplay;
        PlaceTrap.UIOnPlacedClaymoreTrap -= UpdateTrapCounterDisplay;
    }

    public static void UpdateTrapCounterDisplay()
    {
        // Temporary fix.
        GameObject tcd = GameObject.FindWithTag("TrapsCountDisplay");
        tcd.gameObject.GetComponent<TextMeshProUGUI>().SetText("Traps: " + TrapInventory.trapsInInventoryCount);
    }

    public static void UpdateTrapFameScoreDisplay()
    {
        //FAME_SCORE_DISPLAY.GetComponent<TextMeshPro>().SetText("Fame: ");
    }

    public static void UpdateTrapHouseSinkingRateDisplay()
    {
        //HOUSE_SINKING_RATE_DISPLAY.GetComponent<TextMeshPro>().SetText("House Sinking Rate: m/s");
    }
}
