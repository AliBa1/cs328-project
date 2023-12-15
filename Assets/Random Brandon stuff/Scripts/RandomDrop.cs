using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    public Transform powerupPrefab;
    private bool spawned = false;
    void Start()
    {
        Damagable damageableComponent = GetComponent<Damagable>();
    }

    // Update is called once per frame
    void Update()
    {
        Damagable damageableComponent = GetComponent<Damagable>();
        if(damageableComponent != null)
        {
            if(damageableComponent._health <= 0 && spawned == false)
            {
                RandomSpawn();
            }
        }
    }

    private void RandomSpawn()
    {
        float randomValue = Random.value;

        if(randomValue < .2f)
        {
            Instantiate(powerupPrefab, transform.position, Quaternion.identity);
        }
        spawned = true;
    }
}
