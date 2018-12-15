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
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        healthBar.value = healthPoints / maxHealth;
        Vector2 truePos = new Vector2(
            (float) (0.05 + screenPos.x) * Screen.width + 10000,
            (float) (0.25 + screenPos.y) * Screen.height + 10000
        );
        print(truePos);
        healthBar.GetComponent<RectTransform>().anchoredPosition = truePos;
    }

    void OnDestroy() {
        Destroy(healthBar.gameObject);
    }
}
