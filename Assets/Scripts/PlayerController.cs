using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D Collider;

    void Start()
    {
        Collider = Collider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;

        //Run
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (speed > 0)
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
}
