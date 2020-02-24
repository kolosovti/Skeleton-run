using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceVertical = 5.0f;
    [SerializeField] private float forceHorisontal = 2.0f;
    private Rigidbody2D objectRB;
    private Vector2 direction;

    void Start()
    {
        objectRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            direction += Vector2.right;
        }

        direction.x *= forceHorisontal;
        direction.y *= forceVertical;
        objectRB.velocity += direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
