using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public event EventHandler PlayerCollided;

    public static Player Instance { get; private set; }

    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private float moveSpeedX = 0.0005f;
    [SerializeField] private float jumpMax = 10f;
    [SerializeField] private float gravityMultiplier = 1f;
    [SerializeField] private float gravityMax = -10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    Rigidbody2D rb;
    int playerHealth = 3;


    bool isCollided;

    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity += new Vector2(moveSpeedX, 0);
    }

    void Update()
    {
        Move();

        Debug.Log(IsAlive());
    }

    public void Move()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocityY = 0;
            rb.linearVelocityY += jumpPower;
        }
        rb.linearVelocityY -= gravityMultiplier;

        if (rb.linearVelocityY > jumpMax)
        {
            rb.linearVelocityY = jumpMax;
        }
        if (rb.linearVelocityY < gravityMax)
        {
            rb.linearVelocityY = gravityMax;
        }
        Debug.Log(rb.linearVelocityY);
    }

    public bool IsAlive()
    {
        float playerRadius = 0.5f;
        isCollided = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(playerRadius, playerRadius), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (isCollided)
        {
            playerHealth -= 1;
        }

        if (playerHealth <= 0)
        {
            PlayerCollided?.Invoke(this, EventArgs.Empty);
        }

        return playerHealth > 0;
    }
}
