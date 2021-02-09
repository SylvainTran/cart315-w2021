using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MenteBacata.ScivoloCharacterController;
using MenteBacata.ScivoloCharacterControllerDemo;

public class MonsterAI : Bot
{
    float wanderRadius = 0.2f;
    float wanderDistance = 0.4f;
    float wanderJitter = 0.6f;

    public void Update()
    {
        Wander();
        if (!coolDown)
        {
            // Wander until in range of player
            if (CanSeeTarget() && TargetCanSeeMe())
            {
                //Pursue();
            }
        }
    }
}
