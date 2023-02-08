using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Start : MonoBehaviour
{
    public GameObject Player;

    private void Awake()
    {
        PlayerReset();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (Player.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level start");
        }
    }

    public void PlayerReset()
    {
        Player.gameObject.transform.position = transform.position;
    }
}