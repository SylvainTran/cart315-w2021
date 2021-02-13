using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTraps : MonoBehaviour
{
    // Events for the UI
    public delegate void UpdateUIBuyClaymoreTrap();
    public static event UpdateUIBuyClaymoreTrap UIOnBuyClaymoreTrap;

    void OnEnable()
    {
        TrapShopController.OnBuyClaymoreTrap += GetClaymoreTrap;
    }


    void OnDisable()
    {
        TrapShopController.OnBuyClaymoreTrap -= GetClaymoreTrap;
    }

    void GetClaymoreTrap()
    {
        // Add to inventory if not full already
        if (TrapInventory.trapsInInventoryCount < TrapInventory.TRAP_MAX_AMOUNT)
        {
            Debug.Log("Adding a claymore trap to inventory");
            ++TrapInventory.trapsInInventoryCount;
            // This uses the Scriptable Object Constructor instead of invoking "new ClaymoreTrap()"
            ClaymoreTrap claymoreTrap = ScriptableObject.CreateInstance<ClaymoreTrap>();
            TrapInventory.AddToInventory(claymoreTrap);
            // Update UI via event
            UIOnBuyClaymoreTrap();
        }
        else
        {
            Debug.Log("Inventory full.");
        }
    }
}
