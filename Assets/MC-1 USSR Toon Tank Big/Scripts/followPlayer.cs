using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    Transform player;
    Transform tank;
    UnityEngine.AI.NavMeshAgent nav;
    public float distance;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tank = GameObject.FindGameObjectWithTag("Tank").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(Vector3.Distance(player.position, tank.position) <= distance)
        {
            nav.SetDestination(player.position);
        }
    }
}
