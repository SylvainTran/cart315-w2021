using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollision : MonoBehaviour
{
    public GameObject player;
    public Vector3 collisionForce;
    public GameObject commentary;
    public GameObject marsBox1;
    public GameObject marsBox2;
    public static bool switch0 = false;
    public static bool switch1 = false;
    public static bool switch2 = false;
    public float contactThreshold = 0.990f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Rigidbody2D>().AddRelativeForce(collisionForce);
        // Trigger text change in the commentary object
        commentary.GetComponent<TextMesh>().text = "Then, one day,\nthere would be\nso many books\nthat she could climb them\nand walk on Mars.";
        commentary.GetComponent<TextMesh>().fontSize = 95;
        //Camera.main.orthographicSize = 9.66f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            this.GetComponent<Rigidbody>().AddRelativeForce(collisionForce);
            Debug.Log("Normal: " + contact.normal.normalized);
            Debug.Log("Point: " + contact.point);
            if (!switch0 && this.gameObject.CompareTag("MarsBox") && (contact.normal.normalized - (-Vector3.up)).y <= contactThreshold) {
                Debug.Log("Contact from above");
                marsBox1 = GameObject.FindGameObjectWithTag("MarsBox1");
                marsBox1.GetComponent<MeshRenderer>().enabled = true;
                marsBox1.GetComponent<BoxCollider>().enabled = true;
                commentary.GetComponent<TextMesh>().text = "If she piled up enough books...";
                switch0 = true;
            }
            else if (!switch1 && this.gameObject.CompareTag("MarsBox1") && (contact.normal.normalized - (-Vector3.up)).y <= contactThreshold)
            {
                Debug.Log("Contact from above");
                marsBox2 = GameObject.FindGameObjectWithTag("MarsBox2");
                marsBox2.GetComponent<MeshRenderer>().enabled = true;
                marsBox2.GetComponent<BoxCollider>().enabled = true;
                //Camera.main.orthographicSize = 4.47f;
                commentary.GetComponent<TextMesh>().text = "...baby little books each day...";
                //commentary.transform.position
                switch1 = true;
            }
            else if (!switch2 && this.gameObject.CompareTag("MarsBox2") && (contact.normal.normalized - (-Vector3.up)).y <= contactThreshold)
            {
                Debug.Log("Contact from above");
                commentary.GetComponent<TextMesh>().text = "...and ate a lot of daddy's candies...";
                switch2 = true;
            }
            Debug.Log("Difference: " + (contact.normal.normalized - (-Vector3.up)).y);
        }
    }
}
