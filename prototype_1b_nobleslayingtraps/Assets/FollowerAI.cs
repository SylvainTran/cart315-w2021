using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerAI : Bot
{
    float wanderRadius = 1f;
    float wanderDistance = 1f;
    float wanderJitter = 1.5f;
    public float maxFollowDistance = 2f;

    public void Update()
    {
        float d = Vector3.Distance(this.transform.position, target.transform.position);
        Debug.Log("Distance to player: " + d);
        if (CanSeeTarget() && d <= maxFollowDistance && TargetCanSeeMe())
        {
            Seek(target.transform.position);
        }
    }
}
