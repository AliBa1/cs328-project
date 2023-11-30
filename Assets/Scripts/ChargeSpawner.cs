using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSpawner : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject charge;
    public void FireCharge() {
        GameObject projectile = Instantiate(charge, launchPoint.position, charge.transform.rotation);
        Vector3 originalScale = projectile.transform.localScale;
        projectile.transform.localScale = new Vector3(
            originalScale.x * transform.localScale.x > 0 ? 1 : -1,
            originalScale.y,
            originalScale.z
        );
    }
}
