using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string pickUpTag = "PickUpItem";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(pickUpTag))
        {
            Debug.Log("Picking up gem.");
            Destroy(collision.gameObject);
        }
    }
}
