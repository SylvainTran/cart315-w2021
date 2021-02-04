using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAxisConstraints : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);      
    }
}
