using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public GameObject LevelSelector;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        SoundManager.Instance.Play(SoundEvents.ButtonClick);
        Application.Quit();
    }

    private void PlayGame()
    {
        SoundManager.Instance.Play(SoundEvents.ButtonClick);
        LevelSelector.SetActive(true);
    }
}
