using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInventory : MonoBehaviour
{
    public static int TRAP_MAX_AMOUNT = 3; // Max traps
    public static int trapsInInventoryCount = 0; // How many traps currently have
    public static List<Trap> traps;

    private void Start()
    {
        traps = new List<Trap>();
    }

    // LINQ command to check if any trap of type T is in the inventory
    public static bool HasTrapsOfType<T>() where T : Trap
    {
        return traps.Any(t => t is T);
    }

    public static void AddToInventory(Trap trap)
    {
        traps.Add(trap);
    }
}
