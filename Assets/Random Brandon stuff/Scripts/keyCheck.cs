using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCheck : MonoBehaviour
{
    private KeyScript keyScript;
    private Collider2D door;
    // Start is called before the first frame update
    void Awake()
    {
        keyScript = GameObject.FindGameObjectWithTag("Key").GetComponent<KeyScript>();
        door = GetComponent<CompositeCollider2D>();
    }
    private void Start()
    {
        door.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyScript.HasKey())
        {
            Debug.Log("Enter Boss Room");
            door.isTrigger = true;
        }
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


