using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    // target to seek
    public GameObject target;
    public float minFollowDist = 5.0f;
    private NavMeshAgent nav;

    public void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    public void Seek(Vector3 target)
    {
        nav.SetDestination(target);
    }

    public void Update()
    {
        Seek(target.transform.position);
    }
}
