using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleForce : MonoBehaviour
{
    public Vector3 relForce;
    private Vector3 originPos;
    private Quaternion originRot;
    public float latitude;
    public float longitude;
    public float twist = -500f;
    private void Start()
    {
        originPos = this.transform.position;
        originRot = this.transform.rotation;
        relForce = new Vector3(latitude, twist, longitude);
    }
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(relForce);
        // Pop up opt-out option
    }
}
