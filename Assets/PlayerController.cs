using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpPower;
    [SerializeField] float up;
    //[SerializeField] float airMovement;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundLayer;

    bool isGrounded;
    bool canDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isGrounded)
            {
                JumpPlayer(-jumpPower);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                JumpPlayer(-jumpPower);
                canDoubleJump = false;
            }
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (isGrounded)
            {
                JumpPlayer(jumpPower);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                JumpPlayer(jumpPower);
                canDoubleJump = false;
            }
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (!isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector2(horizontalInput, 0), ForceMode2D.Force);
        }
    }

    void JumpPlayer(float power)
    {
        rb.velocity = new Vector2(power, 0);
        rb.AddForce(Vector2.up * up, ForceMode2D.Impulse);
    }
}
