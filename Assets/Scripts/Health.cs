using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    protected Canvas canvas;
    protected float healthPoints;
    public float maxHealth;

    protected bool dead = false;

    protected Text text;

     public ParticleSystem explosion;
    public AudioClip impact;
    AudioSource audioSource;

    void Start() {
        Refresh();
        text = canvas.GetComponentInChildren<Text>();
                audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage) {
        healthPoints -= damage;
        Refresh();
        if (healthPoints <= 0) {
            Animator anim = GetComponent<Animator>();
            if (anim && anim.CompareTag("Player")) {
                anim.SetTrigger("Dead");
                GetComponent<Collider>().enabled = false;
                GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
                dead = true;
                Time.timeScale *= 0.2f;
            } else {
                print("xd");
                Instantiate(explosion, transform.position, transform.rotation);
             audioSource.PlayOneShot(impact, 0.7F);
                Destroy(gameObject);
            }
        }
    }

    public virtual void Refresh() {

    }
}
