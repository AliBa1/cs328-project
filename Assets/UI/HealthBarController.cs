using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    public Slider slider;
    // public Gradient gradient;
    public Image fill;

    Damagable playerDamagable;

    // public void SetMaxHealth(int health) {
    //     slider.maxValue = health;
    //     slider.value = health;

    //     fill.color = gradient.Evaluate(1f);
    // }

    // public void SetHealth(int health) {
    //     slider.value = health;
    //     fill.color = gradient.Evaluate(slider.normalizedValue);
    // }

    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) {
            Debug.Log("No player in scene. Make sure player has 'Player' tag assigned to it.");
        }

        playerDamagable = player.GetComponent<Damagable>();
    }

    private void Start() {
        slider.value = CalculateSliderPercentage(playerDamagable.Health, playerDamagable.MaxHealth);
    }

    private void OnEnable() {
        playerDamagable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable() {
        playerDamagable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(int currentHealth, int maxHealth) {
        return currentHealth/maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth) {
        slider.value = CalculateSliderPercentage(newHealth, maxHealth);
    }

}
