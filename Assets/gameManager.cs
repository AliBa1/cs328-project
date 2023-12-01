using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public List<Damagable> allDamagables = new List<Damagable>();

    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        foreach (Damagable damagable in allDamagables)
        {
            damagable.Health = 100;
        }
    }
}
