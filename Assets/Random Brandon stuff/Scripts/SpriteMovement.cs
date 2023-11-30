using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float amp;
    public float freq;
    private Vector3 initalPos;

    private void Awake()
    {
        amp = 0.3f;
        freq = 2f;
        initalPos = transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(initalPos.x, Mathf.Sin(Time.time * freq) * amp + initalPos.y, 0);
    }
}
