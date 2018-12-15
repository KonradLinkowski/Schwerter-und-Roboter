using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    public Canvas canvas;
    private Slider healthBar;
    public Slider bar;

    public void Start() {
        healthBar = Instantiate(bar, canvas.transform);
        healthPoints = maxHealth;
    }

    public void Update() {
        if (Input.GetKey(KeyCode.X)) {
            
            healthPoints += 1;
        } else if (Input.GetKey(KeyCode.Z)) {
            healthPoints -= 1;
        }
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        print(screenPos);
        healthBar.value = healthPoints / maxHealth;
        healthBar.GetComponent<RectTransform>().anchoredPosition = screenPos + new Vector2(70.0f, 120.0f);
    }
}
