using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject LevelStart;
    private Animator animator;
    private Rigidbody2D Body;
    public float speed;
    public float jump;
    private float horizontal;
    private float vertical;
    private bool IsGrounded;
    public GameObject[] Heart;
    private int Lives = 3;

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

    //
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
