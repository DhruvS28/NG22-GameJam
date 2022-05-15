using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform submarine;

    public float speed;

    // public Vector3 offset;

    void Start()
    {
        speed = 0.125f;
        // offset = new Vector3(0f, 0f, -1f);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(submarine.position.x, 0f, -1f); 
    }
}


