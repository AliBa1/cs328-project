using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatTextManager : MonoBehaviour
{
    public GameObject damageTextPrefab;

    public Canvas gameCanvas;

    private void OnEnable() {
        EnemyEvents.enemyDamaged += EnemyTookDamage;
    }

    private void OnDisable() {
        EnemyEvents.enemyDamaged -= EnemyTookDamage;
    }

    private void Awake() {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    public void EnemyTookDamage(GameObject enemy, int damageReceived) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }
}
