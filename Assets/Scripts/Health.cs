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

    void Start() {
        Refresh();
        text = canvas.GetComponentInChildren<Text>();
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
                Destroy(gameObject);
            }
        }
    }

    public virtual void Refresh() {

    }
}
