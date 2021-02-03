using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollision : MonoBehaviour
{
    public GameObject player;
    public Vector3 collisionForce;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
            this.GetComponent<Rigidbody>().AddRelativeForce(collisionForce);
        }
    }
}
