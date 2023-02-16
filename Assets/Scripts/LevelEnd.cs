using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public Button ResetButton;
    private GameObject WinScreen;
    public Button QuitButton;

    private void Awake()
    {
        WinScreen = GameObject.Find("GameWinScreen");
        WinScreen.SetActive(false);
        ResetButton.onClick.AddListener(ResetLevel);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ScoreDisplay.ScoreValue >= 50 && collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("The Level has ended!");
            WinScreen.SetActive(true);
            playerController.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerController.enabled = false;
        }
    }

    private void ResetLevel()
    {
        Debug.Log("You Died!");
        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
