using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float translation = 0.000005f;
    public float zoomOutSize = .25f;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = zoomOutSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, translation, 0);
    }
}
