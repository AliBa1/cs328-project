using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarV2Controller : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthBarText;

    Damagable playerDamagable;

    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) {
            Debug.Log("No player in scene. Make sure player has 'Player' tag assigned to it.");
        }

        playerDamagable = player.GetComponent<Damagable>();
    }

    private void Start() {
        slider.value = CalculateSliderPercentage(playerDamagable.Health, playerDamagable.MaxHealth);
        healthBarText.text = "You " + playerDamagable.Health + " / " + playerDamagable.MaxHealth;
    }

    private void OnEnable() {
        playerDamagable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable() {
        playerDamagable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth) {
        return currentHealth/maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth) {
        slider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "You " + newHealth + " / " + maxHealth;
    }

}
