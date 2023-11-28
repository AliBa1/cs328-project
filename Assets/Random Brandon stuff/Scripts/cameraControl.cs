using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float translation;
    public float zoomOutSize;
    // Start is called before the first frame update
    void Awake()
    {
        zoomOutSize = 12f;
        Camera.main.orthographicSize = zoomOutSize;
        translation = .003f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, translation, 0);
    }
}
