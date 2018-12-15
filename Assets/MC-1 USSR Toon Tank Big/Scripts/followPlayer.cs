using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    public float distance;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) <= distance)
        {
            nav.SetDestination(player.position);
        }
    }
}
