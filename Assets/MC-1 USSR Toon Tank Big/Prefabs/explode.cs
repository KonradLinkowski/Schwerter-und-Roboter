using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public ParticleSystem explosion;
    Transform player;
    public AudioClip impact;
    AudioSource audioSource;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter (Collision col) {
      if(col.transform == player){
             Instantiate(explosion, transform.position, transform.rotation);
             audioSource.PlayOneShot(impact, 0.7F);
             Destroy(gameObject);
      }
 }

}
