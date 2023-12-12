using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float translation = .01f;
    public float zoomOutSize = 12f;
    // Start is called before the first frame update
    void Awake()
    {
        // zoomOutSize = 12f;
        Camera.main.orthographicSize = zoomOutSize;
        // translation = .03f;
    }

    // Update is called once per frame
    void Update()
    {  
        transform.Translate(0, translation, 0);
    }
}
