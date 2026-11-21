using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f; 

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isGrounded; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

      
        if (moveInput < 0)
        {
            sprite.flipX = true; 
        }
        else if (moveInput > 0)
        {
            sprite.flipX = false; 
        }

       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; 
        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
