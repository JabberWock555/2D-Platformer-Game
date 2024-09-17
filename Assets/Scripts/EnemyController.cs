using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 1f;
    private Animator animator;
    Rigidbody2D EnemyBody;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        EnemyBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Transform PlayerPosition = collision.gameObject.transform;
            transform.localScale = new Vector2(-Mathf.Sign(PlayerPosition.localScale.x), PlayerPosition.localScale.y);
            animator.SetBool("Attack",true);
            EnemyBody.velocity = new Vector2(0, 0);
            playerController.DamagePlayer();
            SoundManager.Instance.Play(SoundEvents.EnemyAttack);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Attack", false);
        EnemyMovement();
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Ground")
        { 
            transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), transform.localScale.y);
        }
    }

    private void EnemyMovement()
    {
        if (IsFacingRight())
        {
            EnemyBody.velocity = new Vector2(Speed, 0f);
        }
        else
        {
            EnemyBody.velocity = new Vector2(-Speed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0.1f;
    }
}
