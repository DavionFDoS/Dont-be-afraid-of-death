using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public GameObject[] GroundCheckers;
    public float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayer;
    public float JumpForce = 10.0f;
    public float Speed = 10.0f;

    private Rigidbody2D _rb;
    private bool _isGrounded;
    private const string HorizontalAxis = "Horizontal";

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheckers[0].transform.position, GroundCheckRadius, GroundLayer) ||
            Physics2D.OverlapCircle(GroundCheckers[1].transform.position, GroundCheckRadius, GroundLayer);

        float horizontalInput = Input.GetAxis(HorizontalAxis); 

        Vector2 velocity = _rb.velocity;
        velocity.x = horizontalInput * Speed;
        _rb.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
