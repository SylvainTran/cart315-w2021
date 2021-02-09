using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MenteBacata.ScivoloCharacterController;
using MenteBacata.ScivoloCharacterControllerDemo;

public class MonsterAI : Bot
{
    public void CloseCorridors()
    {
        int closeDoorsAreaMask = (1 << 0) | (1 << 3);
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        nav.areaMask = closeDoorsAreaMask;
    }

    public void SetAllAreaMask()
    {
        int openAllAreasMask = (1 << 0) | (1 << 2) | (1 << 3);
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        nav.areaMask = openAllAreasMask;
    }

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
