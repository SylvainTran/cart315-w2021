using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLieTruth : MonoBehaviour
{
    GameObject springJointColumn;
    [Range(250f, 5000f)]
    public float explosionForce = 1000f;

    private void Start()
    {
        springJointColumn = GameObject.FindGameObjectWithTag("SpringJointColumn");
    }
    public void ChooseLie()
    {
        Debug.Log("Choose lie");
        springJointColumn.GetComponent<Rigidbody>().AddRelativeTorque(springJointColumn.transform.position);
    }

    public void ChooseTruth()
    {
        Debug.Log("Choose truth");
    }
}
