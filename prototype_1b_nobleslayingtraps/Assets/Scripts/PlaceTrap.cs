using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrap : MonoBehaviour
{
    public GameObject claymoreTrap;
    public GameObject gravityTrap;
    public GameObject loveTrap;
    public GameObject fartTrap;
    public GameObject timeTrap;
    public GameObject nukeTrap;
    public GameObject placeTrapAim;
    //private float delay = 45.0f;
    public enum TRAP_TYPES { CLAYMORE, GRAVITY, LOVE, C4, TIME, NUKE, MAGNET };

    // Events for the UI
    public delegate void UpdateUIPlacedClaymoreTrap();
    public static event UpdateUIPlacedClaymoreTrap UIOnPlacedClaymoreTrap;

    /**
     * ApplyPlaceClaymoreTrap()
     * 
     * Place traps on input
     */
    public void ApplyPlaceTrap(int TRAP_TYPE)
    {
        if(!GetComponent<MenteBacata.ScivoloCharacterControllerDemo.SimpleCharacterController>().isGrounded) {
            return;
        }
        if(TrapInventory.trapsInInventoryCount == 0)
        {
            Debug.Log("No traps to place.");
            return;
        }
        // Check inventory for a trap of the type
        if(TRAP_TYPE == 0 && TrapInventory.HasTrapsOfType<ClaymoreTrap>())
        {
            Debug.Log("Placing a claymore trap!");
            GameObject.Instantiate(claymoreTrap, placeTrapAim.transform.position, Quaternion.identity);
            --TrapInventory.trapsInInventoryCount;
            int indexTrap = TrapInventory.traps.FindIndex(t => t.TrapID == 1);
            if (indexTrap > -1)
            {
                Debug.Log("Removing claymore trap");
                TrapInventory.traps.RemoveAt(indexTrap);
                // Re-update UI
                UIOnPlacedClaymoreTrap();
            }
        }
    }

    /**
     * FixedUpdate()
     * 
     * Native fixed update frame.
     * Variation ideas: Place at certain locations only constraint.
    */
    private void Update()
    {
        // Get input. TODO replace with new input action system.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ApplyPlaceTrap((int)TRAP_TYPES.CLAYMORE);
        }
    }
}
/**
Ray clickRay = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
RaycastHit result;
if(Physics.Raycast(clickRay, out result))
{
    if (result.collider.gameObject.CompareTag("Ground"))
    {
        GameObject.Instantiate(claymoreTrap, result.point, Quaternion.identity);
    }
}
*/
