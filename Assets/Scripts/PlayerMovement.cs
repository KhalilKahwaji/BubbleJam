using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";
    public float speed = 5f;
    public float direction = 1.0f;
    public float abilityPower = 10f;
    public float jumpForce = 7f;

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sp;

    public bool isGrounded = true;
    public float activateBubbleDelay = 1f;
    public bool isWalking = false;

    void PlayerMovementKeyboard()
    {
        float movementX = Input.GetAxis("Horizontal");

        direction = Input.GetAxisRaw("Horizontal");

        //dash ability
        if (Input.GetKeyDown(KeyCode.C) && direction != 0f)
        {
            rigidbody2D.AddForce(new Vector2(abilityPower * direction, 0f), ForceMode2D.Impulse);
        }
        if (direction > 0)
        {
            sp.flipX = false;
            isWalking = true;
        }
        else if (direction < 0)
        {
            sp.flipX = true;
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        transform.position += new Vector3(direction, 0f, 0f) * (speed * Time.deltaTime);

    }

    IEnumerator ActivateBubble()
    {
        yield return new WaitForSeconds(activateBubbleDelay);

        Transform firstChild = transform.GetChild(0);
        if (firstChild != null)
        {
            if(rigidbody2D.gravityScale < 0)
                firstChild.gameObject.SetActive(true);
        }
    }
    void GravitySwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rigidbody2D.gravityScale *= -1;
            jumpForce *= -1;
            transform.Rotate(new Vector3(180, 0, 0));

            if(rigidbody2D.gravityScale == -1)
            {
               animator.StopPlayback();
               animator.Play("gravitySwap");
               StartCoroutine(ActivateBubble());
            }
            else
            {
                animator.StopPlayback();
                transform.GetChild(0).gameObject.SetActive(false);
                animator.StopPlayback();
                animator.Play("bubblePop");
            }
        }
    }

    void PlayerJump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }


    void AnimatePlayer()
    {
        if(isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovementKeyboard();
        PlayerJump();
        GravitySwitch();
        AnimatePlayer();

        //Vector3 currentRotation = transform.eulerAngles;
        //transform.eulerAngles = new Vector3(currentRotation.x, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("Player is grounded!");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = false;
            Debug.Log("Player is not grounded!");
        }
    }
}
