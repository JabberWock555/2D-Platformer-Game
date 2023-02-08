using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Start : MonoBehaviour
{
    public GameObject Player;

    private void Awake()
    {
        Player.transform.position = transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Level start");
    }
}