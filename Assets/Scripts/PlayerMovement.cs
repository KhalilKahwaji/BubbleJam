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

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sp;

    public bool isGrounded = true;


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
        }
        else if (direction < 0)
        {
            sp.flipX = true;
        }

        transform.position += new Vector3(direction, 0f, 0f) * (speed * Time.deltaTime);

    }

    void PlayerJump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        PlayerJump();
      
        transform.eulerAngles = new Vector3(0, 0, 0);
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
