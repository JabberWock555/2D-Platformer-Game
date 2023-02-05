using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D Collider;
    public float speed;
    void Start()
    {
        Collider = Collider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal);
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        //Run
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
            vertical = 0;
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

    private void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
}
