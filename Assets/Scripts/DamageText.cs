using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0, -3, 0);
    public float timeToFade = 1f;
    RectTransform textTransform;
    TextMeshProUGUI textMeshPro;

    private float timeElapsed = 0f;
    private Color startColor = new Color(255, 255, 255);

    private void Awake() {
        textTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        textTransform.position += moveSpeed * Time.deltaTime;

        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeToFade) {
            Destroy(gameObject);
        } else {
            float fadeAlpha = startColor.a * (1 - (timeElapsed/timeToFade));
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }
    }
}
