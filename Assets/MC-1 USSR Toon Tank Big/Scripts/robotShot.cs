using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotShot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public float timesBetweenShots;
    float timeBetweenShots;
    public float timeBetweenHans;
    Transform player;
    Transform tank;
    public float distance;
    private float timestamp = 0.0f;
    private float timestampHans = 0.0f;
    public AudioClip impact;
    public AudioClip hansVoice;
    AudioSource audioSource;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tank = GameObject.FindGameObjectWithTag("Tank").transform;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timestamp += Time.deltaTime;
        timestampHans += Time.deltaTime;

        timeBetweenShots = Random.Range(0.0f, timesBetweenShots);

        if (Vector3.Distance(player.position, tank.position) <= distance)
        {
            if (timestamp >= timeBetweenShots)
            {
                audioSource.PlayOneShot(impact, 0.7F);
                GameObject temp = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                temp.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * 100);
                timestamp = 0.0f;
            }

            if(timestampHans >= timeBetweenHans)
            {
                audioSource.PlayOneShot(hansVoice, 0.7f);
                timestampHans = 0.0f;
            }
        }
    }
}
