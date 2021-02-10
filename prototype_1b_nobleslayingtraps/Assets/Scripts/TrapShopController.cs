using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShopController : MonoBehaviour
{
    // Dependent GOs - TO REFACTOR with events
    public GameObject trapShopUI;
    public GameObject cameraGO;
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
