using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 50)] private float Hight;
    [SerializeField, Min(1)] private float Speed;
    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private AudioSource jumpSound;

    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private Animator anim;

    private float dirX = 0f;
    //private float dirY = 0f;
    
    private enum MovementState {idle, running, jumping, falling }
    //private MovementState State = MovementState.idle;



    // Start is called before the first frame update
    void Start()
    {
       rb= GetComponent<Rigidbody2D>();
       coll = GetComponent<BoxCollider2D>();
       sprite = GetComponent<SpriteRenderer>();
       anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*Speed,rb.velocity.y);
       // dirY = Input.GetAxisRaw("Vertical");

        UpdateAnim();
    }
    private void UpdateAnim()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, Hight);
            
           
        }
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
           
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y> .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
            state = MovementState.falling;

        anim.SetInteger("state", (int)state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
