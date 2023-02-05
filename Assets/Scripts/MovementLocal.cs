using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementLocal : MonoBehaviour
{
    Vector2 movementVector;
    bool OnHitting = false;
    bool OnJumping = false;
    float distToGround = 2f;
    [SerializeField] LayerMask jumableGround;
    [SerializeField] float mvoement_speed;
    [SerializeField] float Jump_force;
    [SerializeField] bool triggerShake = false;
    Vector2 Velocity; 
    Rigidbody2D rb;
    Animator Anim;
    SpriteRenderer spriteRender;
    float originalGravity;
    Vector2 prepos = Vector2.zero;
    Vector2 postpos = Vector2.zero;
    

    void Start()
    {
        postpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        originalGravity = rb.gravityScale;

    }

    
    public void OnMove(InputAction.CallbackContext ctx)
    {  
        movementVector = ctx.ReadValue<Vector2>();
    }

    public void OnPunching(InputAction.CallbackContext ctx)
    {  
        OnHitting = ctx.action.triggered;
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {  
        OnJumping = ctx.action.triggered;
    }

    void  PlayAnim(string animation)
    {
        Anim.Play(animation);
        return;
    }

    bool IsGrounded() 
    {
        rb.gravityScale = originalGravity;
        return Physics2D.BoxCast(GetComponent<CapsuleCollider2D>().bounds.center, GetComponent<CapsuleCollider2D>().bounds.size - (new Vector3(0.2f,0,0)), 0f, Vector2.down, .1f, jumableGround);
    }

    void Update()
    {
        
        if(movementVector.x>0)
        {
            spriteRender.flipX = false;
        }
        else if(movementVector.x<0)
        {
            spriteRender.flipX = true;
        }


        Velocity = new Vector2(movementVector.x * mvoement_speed, rb.velocity.y);

        // IsAxesDown(fireInput,() => PlayAnim("punch"));

        if(OnJumping && IsGrounded())
        {
            Velocity.y = Jump_force;
        }

        if(OnHitting)
        {
            PlayAnim("punch");
        }

        if(movementVector.x != 0 && movementVector.y == 0) {
            //Play your sideways animation
            Anim.SetBool("isRunning",true);
        }
        else
        {
            Anim.SetBool("isRunning",false);
        }

        rb.velocity = Velocity;

        if(triggerShake)
        {
            Camera.main.GetComponent<Shake>().shake_camera();
        }

    }

    void FixedUpdate()
    {
        //Debug.Log(prepos + "  -  " + postpos);
       
        

        if(!IsGrounded())
        {
            postpos = transform.position;
            Anim.SetBool("OnGround",false);
            if(prepos.y < postpos.y)
            {
                //falling
                rb.gravityScale +=2;
                PlayAnim("Jump");
            }
            else if(prepos.y > postpos.y)
            {
                //rising
                
                PlayAnim("JumpEnd");

            }
            prepos = postpos;
        }
        else
        {
            Anim.SetBool("OnGround",true);
        }

        
    }
}
