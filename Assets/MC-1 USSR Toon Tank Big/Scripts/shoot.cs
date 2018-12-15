using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public float timeBetweenShots;
    Transform player;
    Transform tank;
    public float distance;
    private float timestamp = 0.0f  ;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tank = GameObject.FindGameObjectWithTag("Tank").transform;
    }

    void Update()
    {
        timestamp += Time.deltaTime;

        if (Vector3.Distance(player.position, tank.position) <= distance)
        {
            if (timestamp >= timeBetweenShots)
            {
                GameObject temp = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                temp.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * 100);
                timestamp = 0.0f;
            }
        }
    }
}
