using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceVertical;
    private Rigidbody2D objectRigidBody;
    private bool isGrounded;
    private GameController gameController;

    void Start()
    {
        gameController = GameController.Instance;
        objectRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        objectRigidBody.velocity += GetDirection();
    }

    private Vector2 GetDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded) 
            direction += Vector2.up;
        if (Input.GetKeyDown(KeyCode.S))
            direction += Vector2.down;

        direction.y *= forceVertical;

        return direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "DeathBorder")
        {
            GameController.Instance.GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
