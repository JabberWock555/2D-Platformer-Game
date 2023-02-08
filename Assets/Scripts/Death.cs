using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject LevelStart;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OOPS! Try Again");
        Player.gameObject.transform.position = LevelStart.gameObject.transform.position;
    }
}
