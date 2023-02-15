using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject LevelStart;
    public float speed;
    public float jump;
    public GameObject[] Heart;

    private Animator animator;
    private Rigidbody2D Body;
    private float horizontal;
    private bool vertical;
    private bool IsGrounded;
    private int Lives = 3;
    private bool DoubleJump;

    private IEnumerator Delay(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
         horizontal = Input.GetAxisRaw("Horizontal");
         vertical = Input.GetKeyDown(KeyCode.UpArrow);
         VerticalMovement(vertical);
         HorizontalMovement(horizontal);

        // Death Condition
        if(transform.position.y < -10f)
        { Death();}

        if(ScoreDisplay.ScoreValue == 50)
        {
            Debug.Log("You Won");
        }
    }


    private void VerticalMovement(bool vertical)
    {
        //Jump Animation and Movement

        if (IsGrounded)
        {
            DoubleJump = true;
        }
        if (vertical)
        {
            if (IsGrounded)
            {
                animator.SetBool("JumpUp", true);
                Body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
            else if (!IsGrounded && DoubleJump)
            {
                animator.SetBool("JumpUp", true);
                Body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                DoubleJump = false;
            }
        }
        else if (!IsGrounded && !vertical)
        { 
            animator.SetBool("JumpUp", false);
            animator.SetBool("JumpDown", true);
        }
        else if (IsGrounded && !vertical)
        {
            animator.SetBool("JumpDown", false);
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

    private void HorizontalMovement(float horizontal)
    {

        //Horizontal Movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Run Animation and Flip
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0 )
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }

    //GroundCheck
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Ground")) 
        {
            IsGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            IsGrounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyController>() != null)
        {
            animator.SetBool("Hurt", false);
        }
    }

    //Death Function
    private void Death()
    {
        Debug.Log("You Died!");
        SceneManager.LoadScene(0);
    }

    //Key Collection
    public void Pickup_Key()
    {
        ScoreDisplay.ScoreValue += 10;
        Debug.Log("Picked up a Key!");
    }

    public void DamagePlayer()
    {
        Lives--;
        if (Lives == 0)
        {
            animator.SetTrigger("Dead");
            StartCoroutine(Delay(2f));
            Death();
        }
        animator.SetTrigger("Hurt");
        Heart[Lives].SetActive(false);
       
        
    }

}
