using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miecz : MonoBehaviour
{
    private PlayerHealth player;
    public float damage;
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter(Collider enemy) {
        if (enemy.gameObject.CompareTag("Enemy")) {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth) {
                enemyHealth.TakeDamage(damage);
            }
        }
    }   
}