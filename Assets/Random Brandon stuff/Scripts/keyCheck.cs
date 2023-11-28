using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCheck : MonoBehaviour
{
    private KeyScript keyScript;
    // Start is called before the first frame update
    void Start()
    {
        keyScript = GameObject.FindGameObjectWithTag("Key").GetComponent<KeyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (keyScript.HasKey())
            {
                Debug.Log("Enter Boss Room");
            }
            else
            {
                Debug.Log("Go get key");
            }
        }
    }
}
