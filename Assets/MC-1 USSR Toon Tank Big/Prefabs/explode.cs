using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public float damage;
    public ParticleSystem explosion;
    Transform player;
    public AudioClip impact;
    AudioSource audioSource;
    float deathTimer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        deathTimer += Time.deltaTime;   
        if (deathTimer > 5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter (Collision col) {
      if(col.transform == player){
          print(col);
        col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
             Instantiate(explosion, transform.position, transform.rotation);
             audioSource.PlayOneShot(impact, 0.7F);
             Destroy(gameObject);
      }
 }

}
