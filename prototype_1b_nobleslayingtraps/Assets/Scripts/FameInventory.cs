using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FameInventory : MonoBehaviour
{
    public static int FAME_MAX_AMOUNT = 999; // Max fame
    public static int totalFame = 0; // How many traps currently have

    public static void AddFame(int value)
    {
        Debug.Log("Adding : " + value + " fame.");
        totalFame += value;
    }
}
