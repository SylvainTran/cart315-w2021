using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrapShopController : MonoBehaviour
{
    // Dependent GOs - TO REFACTOR with events
    public GameObject trapShopUI;
    public GameObject cameraGO;
    public GameObject UIGameCanvas;
    // Events for the player BuyTraps() component
    public delegate void BuyClaymoreTrap();
    public static event BuyClaymoreTrap OnBuyClaymoreTrap;

    private void OnTriggerEnter(Collider collider)
    {
        if(!collider.gameObject.CompareTag("Player"))
        {
            return;
        }
        if(!trapShopUI.active)
        {
            trapShopUI.SetActive(true);
            UIGameCanvas.SetActive(false);
            // TODO Disable camera rotating with mouse
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (trapShopUI.active)
        {
            trapShopUI.SetActive(false);
            UIGameCanvas.SetActive(true);
            // Temporary fix.
            GameObject tcd = GameObject.FindWithTag("TrapsCountDisplay");
            if(tcd) {
                tcd.gameObject.GetComponent<TextMeshProUGUI>().SetText("Traps: " + TrapInventory.trapsInInventoryCount);
            }
            // TODO Enable camera rotating with mouse
        }
    }

    public void UIBuyClaymoreTrap()
    {
        OnBuyClaymoreTrap();
    }

    public void BuyGravityTrap()
    {

    }

    public void BuyLoveTrap()
    {

    }

    public void BuyC4()
    {

    }

    public void BuyNukeTrap()
    {

    }

    public void BuyMagnetTrap()
    {

    }
}
