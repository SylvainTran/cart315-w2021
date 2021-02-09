using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrap : MonoBehaviour
{
    public GameObject trapPrefab;
    public GameObject placeTrapAim;

    private float delay = 45.0f;

    /**
     * ApplyPlaceTrap()
     * 
     * Place traps on input
     */
    public void ApplyPlaceTrap()
    {
        if(!GetComponent<MenteBacata.ScivoloCharacterControllerDemo.SimpleCharacterController>().isGrounded) {
            return;
        }
        Debug.Log("Placing trap!");
        GameObject.Instantiate(trapPrefab, placeTrapAim.transform.position, Quaternion.identity);
        /**
        Ray clickRay = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit result;
        if(Physics.Raycast(clickRay, out result))
        {
            if (result.collider.gameObject.CompareTag("Ground"))
            {
                GameObject.Instantiate(trapPrefab, result.point, Quaternion.identity);
            }
        }
        */
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
            ApplyPlaceTrap();
        }
    }
}
