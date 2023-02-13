using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMP_BUTTON = "Jump";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis(HORIZONTAL_AXIS);
        Vector2 velocity = rb.velocity;
        velocity.x = horizontalInput * speed;
        rb.velocity = velocity;

        if (Input.GetButtonDown(JUMP_BUTTON) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
