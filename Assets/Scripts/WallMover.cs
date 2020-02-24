using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    Transform wallTransform;
    Vector3 offset;
    float speed;

    void Start()
    {
        wallTransform = GetComponent<Transform>();
        offset = Vector3.left;
        speed = 0.1f;
    }

    void FixedUpdate()
    {
        wallTransform.position += offset * speed;
    }
}
