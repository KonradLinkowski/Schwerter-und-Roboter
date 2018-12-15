using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public float maxEnergy;
    private float energyPoints;
    
    public Slider energyBar;
    public Slider healthBar;

    public float energyIncome;

    void Start() {
        energyPoints = maxEnergy;
        healthPoints = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            TakeEnergy(30);
        }
        energyBar.value = energyPoints / maxEnergy;
        healthBar.value = healthPoints / maxHealth;
        if (energyPoints <= maxEnergy) {
            energyPoints += energyIncome * Time.deltaTime;
            if (energyPoints > maxEnergy) energyPoints = maxEnergy;
        }
    }

    void TakeEnergy(float energy) {
        energyPoints -= energy;
        if (energyPoints < 0) energyPoints = 0;
    }
}
