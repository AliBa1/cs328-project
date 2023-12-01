using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D collide;
    // Start is called before the first frame update
    private void Awake()
    {
        collide = GetComponent<Collider2D>();
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);
    }

    // Update is called once per frame
    private void onTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);
    }
}
