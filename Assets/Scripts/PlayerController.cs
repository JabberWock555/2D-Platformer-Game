using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LevelStart;
    public Animator animator;
    private BoxCollider2D Collider;
    private Rigidbody2D Body;
    public float speed;
    public float jump;
    private float horizontal;
    private float vertical;
    private bool IsGrounded;
    private int score;
    void Awake()
    {
        Collider = gameObject.GetComponent<BoxCollider2D>();
        Body = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Pickup_Key()
    {
        score += 10;
        Debug.Log("Picked up a Key!");
        Debug.Log("Score:" + score);
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

        if(score == 50)
        {
            Debug.Log("You Won");
        }
    }

    
    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        //Run
        if (horizontal < 0 && IsGrounded)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0 && IsGrounded)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if (vertical > 0 )
        {
            animator.SetBool("Jump", true);
            
        }
        else { animator.SetBool("Jump", false); }

        //crouch
        if (Input.GetKeyDown("left ctrl"))
        {
            animator.SetBool("Crouch", true);
            Collider.size = new Vector2(0.6f, 1.2f);
            Collider.offset = new Vector2(-0.05f, 0.6f);

        }
        else if (Input.GetKeyUp("left ctrl"))
        {
            animator.SetBool("Crouch", false);
            Collider.size = new Vector2(0.6f, 2f);
            Collider.offset = new Vector2(0.05f, 0.97f);
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) 
        {
            IsGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
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

    
}
