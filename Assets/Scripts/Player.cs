using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public event EventHandler<int> PlayerCollided;


    public static Player Instance { get; private set; }

    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private float jumpMax = 10f;
    [SerializeField] private float gravityMultiplier = 1f;
    [SerializeField] private float gravityMax = -10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameHandler gameHandler;

    Rigidbody2D rb;
    int playerHealth = 3;
    bool isPlaying = true;
    Vector3 startingPoint = new Vector3(-12, 5 ,0); 

    bool isCollided;

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

        gameHandler.HealthReduced += GameHandler_HealthReduced;
        gameHandler.GameOver += GameHandler_GameOver;
    }

    private void GameHandler_GameOver(object sender, EventArgs e)
    {
        isPlaying = false;
        transform.position = startingPoint;
    }

    private void GameHandler_HealthReduced(object sender, int e)
    {
        transform.position = startingPoint;
    }

    private void Update()
    {
        Move();

        IsAlive();
    }

    public void Move()
    {
        if (isPlaying)
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
        }
        else
        {
            rb.linearVelocityY = 0;
        }
    }

    public bool IsAlive()
    {
        float playerRadius = 0.5f;
        isCollided = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(playerRadius, playerRadius), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (isCollided && playerHealth > 0)
        {
            playerHealth -= 1;
            PlayerCollided?.Invoke(this, playerHealth);
        }

        return playerHealth > 0;
    }

}
