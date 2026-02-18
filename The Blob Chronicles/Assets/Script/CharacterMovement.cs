using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private InputAction Move;

    private BoxCollider2D playerCollider;

    public int Speed;

    private Vector2 movement, colliderSizeS, colliderOffsetS, colliderSizeC, colliderOffsetC;

    public bool jumping, facingRight, crouching;

    private LayerMask groundLayer;

    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move = InputSystem.actions["Move"];
        Speed = 6;
        rb.linearVelocity = Vector2.zero;
        jumping = false;
        crouching = false;
        groundLayer =  LayerMask.GetMask("Ground");
        rb.freezeRotation = true;
        _animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        colliderSizeS = playerCollider.size;
        colliderOffsetS = playerCollider.offset;
        colliderSizeC = new Vector2(2.03f, 1.06f);
        colliderOffsetC = new Vector2(0f, -1.98f);
    }

    void Update()
    {
        movement = Move.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector2.down, 1.8f, groundLayer);
        
        Debug.DrawRay(transform.position, Vector2.down * 1.8f, Color.red);

        if (crouching)
        {
            playerCollider.size =  colliderSizeC;
            playerCollider.offset = colliderOffsetC;
        }
        else
        {
            playerCollider.size =  colliderSizeS;
            playerCollider.offset = colliderOffsetS;
        }
        

        if (hit && rb.linearVelocityY == 0)
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }

        if (movement.y > 0 && crouching)
        {
            crouching = false;
        }
        
        if (movement.y > 0 && !jumping && !crouching)
        {
            rb.AddForceY(450);
        }

        if (movement.y < 0 && !jumping)
        {
            crouching = true;
        }
        
        transform.Translate(new Vector3(movement.x, 0, 0) *  Speed * Time.deltaTime);
        
        if (movement.x < 0 && !facingRight)
        {
            facingRight = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (movement.x > 0 && facingRight)
        {
            facingRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (movement.x == 0 && !jumping)
        {
            _animator.SetBool("Idle", true);
        }
        else
        {
            _animator.SetBool("Idle", false);
        }

		if (movement.x > 0 && !jumping || movement.x < 0 && !jumping) 
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
        
        
        
        

    }
}
