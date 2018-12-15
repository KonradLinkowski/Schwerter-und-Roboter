using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public float maxEnergy;
    private float energyPoints;
    
    private Slider energyBar;
    private Slider healthBar;

    public float energyIncome;

    void Awake() {
        canvas = GameObject.Find("HealthBars").GetComponent<Canvas>();
        energyBar = GameObject.Find("Energy").GetComponent<Slider>();
        healthBar = GameObject.Find("Health").GetComponent<Slider>();
        energyPoints = maxEnergy;
        healthPoints = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            TakeEnergy(30);
        }
        if (energyPoints <= maxEnergy) {
            energyPoints += energyIncome * Time.deltaTime;
            if (energyPoints > maxEnergy) energyPoints = maxEnergy;
        }
        energyBar.value = energyPoints / maxEnergy;
        if (dead) {
            text.color = Color.Lerp(
                text.color,
                Color.red,
                Time.deltaTime * 3
            );
        }
    }

    public float getEnergy() {
        return energyPoints;
    }

    public void TakeEnergy(float energy) {
        energyPoints -= energy;
        if (energyPoints < 0) energyPoints = 0;
        Refresh();
    }

    public override void Refresh() {
        healthBar.value = healthPoints / maxHealth;
    }
}
