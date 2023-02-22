using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Animator animator;
    private bool Iscollected;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Iscollected && collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Iscollected = true;
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.Pickup_Key();
            animator.SetBool("Collected", true);
            StartCoroutine(End());
            SoundManager.Instance.Play(SoundEvents.KeyPickup);
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
        Iscollected = false;
    }
    }
