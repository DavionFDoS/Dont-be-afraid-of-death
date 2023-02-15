using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float Speed = 10.0f;
    public float JumpForce = 10.0f;
    public float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayer;
    public GameObject[] GroundCheckers;

    private Rigidbody2D rb;
    private bool isGrounded;
    private const string HorizontalAxis = "Horizontal";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckers[0].transform.position, GroundCheckRadius, GroundLayer) ||
            Physics2D.OverlapCircle(GroundCheckers[1].transform.position, GroundCheckRadius, GroundLayer);

        float horizontalInput = Input.GetAxis(HorizontalAxis);
        Vector2 velocity = rb.velocity;
        velocity.x = horizontalInput * Speed;
        rb.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
