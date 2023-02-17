using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public Button NextLevelButton;
    public int WinPoints;
    private Scene ActiveScene;

    private void Awake()
    {
        NextLevelButton.onClick.AddListener(NextLevel);
        ActiveScene = SceneManager.GetActiveScene();
        if (ActiveScene.buildIndex >= 3)
        {
            NextLevelButton.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("The Level has ended!");
            playerController.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerController.enabled = false;
        }
    }

    private void NextLevel()
    {
        if (ActiveScene.buildIndex < 3)
        {
            SceneManager.LoadScene(ActiveScene.buildIndex + 1);
        }
    }

    public void PlayerWin()
    {
        gameObject.SetActive(true);
    }
}
