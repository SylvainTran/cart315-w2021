using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string pickUpTag = "PickUpItem";
    public string forceTag = "Force";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(pickUpTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
