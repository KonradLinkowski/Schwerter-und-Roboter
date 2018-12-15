using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected float healthPoints;
    public float maxHealth;

    public void TakeDamage(float damage) {
        healthPoints -= damage;
        if (healthPoints <= 0) {
            Destroy(gameObject);
        }
    }
}
