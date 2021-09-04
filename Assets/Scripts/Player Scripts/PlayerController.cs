using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    public Transform player;
    public Rigidbody2D playerRigidbody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D friction;

    [Header("Ground")]
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask isGround;

    [Header("Wall Slide")]
    public float wallSlideSpeed;
    public float wallCheckDistance;
    private bool isWallSliding;
    public float wallJumpForce;
    public float wallJumpLength;

    [Header("Values")]
    public float fallMultiplier;
    public float lowJumpMultiplier;

    [Header("Reference to Values")]
    public FloatReference moveSpeed;
    public FloatReference jumpForce;

    bool facingRight = true;

    void Start()
    {
        PlayerManager.instance.onDialogue += SetStatic;
        PlayerManager.instance.onPause += SetStatic;
    }

    void Update()
    {
        if (InputManager.instance.movementX > 0)
        {
            facingRight = true;
        }
        else if (InputManager.instance.movementX < 0)
        {
            facingRight = false;
        }

        //manages wall slide
        WallSlide();
        //manages jump
        JumpStart(InputManager.instance.jumpStart);
        
    }

    //physics should only happen here so that it does not depend on frame rate
    private void FixedUpdate()
    {
        if (InputManager.instance.controlsEnabled && !isWallSliding)
        {
            Movement(InputManager.instance.movementX);
        }
        else
        {
            animator.SetFloat("VelocityX", 0);
        }

        Flip(facingRight);
    }

    void Movement(float x)
    {
        playerRigidbody.velocity = new Vector2(x * moveSpeed * 100 * Time.deltaTime, playerRigidbody.velocity.y);
        animator.SetFloat("VelocityX", Mathf.Abs(x));
    }

    void Flip(bool facingRight)
    {
        if (facingRight)
        {
            player.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            player.localScale = new Vector3(-1, 1, 1);
        }
    }

    void JumpStart(bool jumpStart)
    {

        if (jumpStart && IsGrounded())
        {
            SetStatic();
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        } else if (jumpStart && isWallSliding)
        {
            StartCoroutine(WallJump());
        }

        //faster downwards always
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //downwards faster if not holding jump
        else if (playerRigidbody.velocity.y > 0 && !InputManager.instance.isJumping) 
        {
            playerRigidbody.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        animator.SetFloat("VelocityY", playerRigidbody.velocity.y);
        animator.SetBool("IsGrounded", IsGrounded());


    }

    void WallSlide()
    {
        if (IsTouchingWall() && !IsGrounded() && InputManager.instance.movementX != 0)
        {
            isWallSliding = true;
            animator.SetBool("IsWallSliding", true);
            playerRigidbody.velocity = new Vector2(0, -wallSlideSpeed);
        }
        else
        {
            isWallSliding = false;
            animator.SetBool("IsWallSliding", false);
        }
    }

    bool IsTouchingWall()
    {
        if (facingRight)
        {
            return Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, isGround);
        }
        else
        {
            return Physics2D.Raycast(transform.position, Vector3.left, wallCheckDistance, isGround);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);
    }

    public void SetStatic()
    {
        playerRigidbody.velocity = Vector2.zero;
    }

    void OnDisable()
    {
        PlayerManager.instance.onDialogue -= SetStatic;
        PlayerManager.instance.onPause -= SetStatic;
    }

    IEnumerator WallJump()
    {
        SetStatic();
        InputManager.instance.DisableControls();

        if (facingRight)
        {
            playerRigidbody.AddForce(new Vector2(-1f, 1.15f) * wallJumpForce, ForceMode2D.Impulse);
        }
        else
        {
            playerRigidbody.AddForce(new Vector2(1f, 1.15f) * wallJumpForce, ForceMode2D.Impulse);
        }

        facingRight = !facingRight;
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(wallJumpLength);
        InputManager.instance.EnableControls();
    }
}
