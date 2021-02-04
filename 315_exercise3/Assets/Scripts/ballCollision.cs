using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollision : MonoBehaviour
{
    public GameObject player;
    public Vector3 collisionForce;
    public GameObject commentary;
    public GameObject marsBox0;
    public GameObject marsBox1;
    public GameObject marsBox2;
    public bool switch0 = false;
    public bool switch1 = false;
    public bool switch2 = false;
    public float contactThreshold = 0.990f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Rigidbody2D>().AddRelativeForce(collisionForce);
        // Trigger text change in the commentary object
        commentary.GetComponent<TextMesh>().text = "Then, one day,\nthere would be\nso many books\nthat she could climb them\nand walk on Mars.";
        commentary.GetComponent<TextMesh>().fontSize = 95;
        // Display text after a delay
        // StartCoroutine(StartDialogueNode("Then, one day,\nthere would be\nso many books\nthat she could climb them\nand walk on Mars."));
        // TODO Attach a spring joint to the player and this sphere... walk on Mars effect?
        StartCoroutine(HandleScene.StartChangeScene(7.0f));
    }

    private IEnumerator StartDialogueNode(string dialogue)
    {
        yield return new WaitForSeconds(0.5f);
        commentary.GetComponent<TextMesh>().text = dialogue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //ContactPoint contact = collision.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //Vector3 pos = contact.point;
            this.GetComponent<Rigidbody>().AddRelativeForce(collisionForce);
            //Debug.Log("Normal: " + contact.normal.normalized);
            //Debug.Log("Point: " + contact.point);
            //Debug.Log("Difference y: " + (transform.position.y - player.transform.position.y));
            float yDifference = transform.position.y - player.transform.position.y;
            if (this.gameObject.CompareTag("MarsBox") && yDifference <= 0.0f) {
                marsBox1.GetComponent<MeshRenderer>().enabled = true;
                marsBox1.GetComponent<BoxCollider>().enabled = true;
                commentary.GetComponent<TextMesh>().text = "If she piled up enough books...";
            }
            else if (this.gameObject.CompareTag("MarsBox1") && yDifference <= 0.0f)
            {
                marsBox2 = GameObject.FindGameObjectWithTag("MarsBox2");
                marsBox2.GetComponent<MeshRenderer>().enabled = true;
                marsBox2.GetComponent<BoxCollider>().enabled = true;
                //Camera.main.orthographicSize = 4.47f;
                commentary.GetComponent<TextMesh>().text = "...baby little books each day...";
                // Destroy previous
                Destroy(marsBox0.gameObject);
            }
            else if (!switch2 && this.gameObject.CompareTag("MarsBox2") && yDifference <= 0.0f)
            {
                commentary.GetComponent<TextMesh>().text = "...and ate a lot of daddy's candies...";
                Destroy(marsBox1.gameObject);
                switch2 = true;
            }
        }
    }
}
