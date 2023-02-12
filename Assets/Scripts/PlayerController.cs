using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LevelStart;
    private Animator animator;
    private BoxCollider2D Collider;
    private Rigidbody2D Body;
    public float speed;
    public float jump;
    private float horizontal;
    private float vertical;
    private bool IsGrounded;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        Body = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
         horizontal = Input.GetAxisRaw("Horizontal");
         vertical = Input.GetAxisRaw("Vertical");
        PlayMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
        // Death Condition
        if(transform.position.y < -10f)
        { Death();}

        if(ScoreDisplay.ScoreValue == 50)
        {
            Debug.Log("You Won");
        }
    }


    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        //Run Animation and Flip
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        if (horizontal < 0 && IsGrounded)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0 && IsGrounded)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump Animation
        if (vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //crouch Animation
        if (Input.GetKeyDown("left ctrl"))
        {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp("left ctrl"))
        {
            animator.SetBool("Crouch", false);
        }

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //Horizontal Movement

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Jump
        if(IsGrounded && vertical > 0.1f)
        {
            Body.AddForce(new Vector2(0, jump), ForceMode2D.Force);
        }
    }

    //GroundCheck
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            IsGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    //Death Function
    private void Death()
    {
        Debug.Log("You Died!");
        Vector2 startLocation = LevelStart.transform.position;
        transform.position = startLocation;
    }

    //
    public void Pickup_Key()
    {
        ScoreDisplay.ScoreValue += 10;
        Debug.Log("Picked up a Key!");
    }

    public void KillPlayer()
    {
        animator.SetBool("Dead", true);
        Death();
    }

}
