using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleForce : MonoBehaviour
{
    public Vector3 relForce;
    private Vector3 originPos;
    private Quaternion originRot;
    private float threshold;
    private void Start()
    {
        originPos = this.transform.position;
        originRot = this.transform.rotation;
        relForce = new Vector3(0f, -500f, 0f);
        threshold = 250.0f;
    }
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(relForce);
        // Pop up opt-out option
    }
}
