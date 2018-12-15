using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    private Slider healthBar;
    public Slider bar;

    public void Awake() {
        canvas = GameObject.Find("HealthBars").GetComponent<Canvas>();
        healthBar = Instantiate(bar, canvas.transform);
        healthPoints = maxHealth;
        Refresh();
    }

    public void Update() {
        Refresh();
    }

    public override void Refresh() {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        healthBar.value = healthPoints / maxHealth;
        healthBar.GetComponent<RectTransform>().anchoredPosition = screenPos / 4.5f;
    }

    void OnDestroy() {
        Destroy(healthBar.gameObject);
    }
}
