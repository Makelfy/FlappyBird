using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public static Movement Instance { get; private set; }

    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private float moveSpeedX = 0.0005f;
    [SerializeField] private float gravityMultiplier = 1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    Rigidbody2D rb;
    Vector2 gravityVector;
    int playerHealth = 3;


    bool isCollided;

    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        gravityVector = new Vector2(0, -Physics2D.gravity.y);
    }

    void Update()
    {
        float playerRadius = 1.1f;
        isCollided = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(playerRadius, playerRadius), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(moveSpeedX, jumpPower);
        }
        else 
        {
            rb.linearVelocity += new Vector2(moveSpeedX, 0);
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity -= gravityVector * gravityMultiplier * Time.deltaTime;
        }

        if (isCollided)
        {
            playerHealth -= 0;
        }

    }
    public bool IsAlive()
    {
        return playerHealth > 0;
    }
}
