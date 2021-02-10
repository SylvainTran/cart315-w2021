using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerAI : Bot
{
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
