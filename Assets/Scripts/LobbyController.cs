using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
