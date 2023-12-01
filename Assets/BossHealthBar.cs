using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthBarText;

    Damagable bossDamagable;

    private void Awake() {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");

        if (boss == null) {
            Debug.Log("No boss in scene. Make sure boss has 'Boss' tag assigned to it.");
        }

        bossDamagable = boss.GetComponent<Damagable>();
    }

    private void Start() {
        slider.value = CalculateSliderPercentage(bossDamagable.Health, bossDamagable.MaxHealth);
        healthBarText.text = "Boss " + bossDamagable.Health + " / " + bossDamagable.MaxHealth;
    }

    private void OnEnable() {
        bossDamagable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable() {
        bossDamagable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth) {
        return currentHealth/maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth) {
        slider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "Boss " + newHealth + " / " + maxHealth;
    }

}
