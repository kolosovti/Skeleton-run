using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLiveCycle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyPosition;
    private Transform wallTransform;
    private Vector3 offset;

    void Start()
    {
        wallTransform = GetComponent<Transform>();
        offset = Vector3.left;
    }

    void FixedUpdate()
    {
        wallTransform.position += offset * speed * Time.deltaTime;
        if (wallTransform.position.x < destroyPosition)
            Destroy(gameObject);
    }
}
