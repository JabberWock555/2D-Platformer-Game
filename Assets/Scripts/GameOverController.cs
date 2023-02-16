using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    public Button QuitButton;

    private void Awake()
    {
        gameObject.SetActive(false);
        RestartButton.onClick.AddListener(ReloadLevel);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        Debug.Log("You Died!");
        SceneManager.LoadScene(1);
    }


}
