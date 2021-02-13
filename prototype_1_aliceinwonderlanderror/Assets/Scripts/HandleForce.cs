using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleForce : MonoBehaviour
{
    public Vector3 relForce;
    private Vector3 originPos;
    private Quaternion originRot;
    private float threshold;
    public float latitude;
    public float longitude;
    public float twist = -500f;
    private void Start()
    {
        originPos = this.transform.position;
        originRot = this.transform.rotation;
        relForce = new Vector3(latitude, twist, longitude);
        threshold = 250.0f;
    }
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(relForce);
    }
}
