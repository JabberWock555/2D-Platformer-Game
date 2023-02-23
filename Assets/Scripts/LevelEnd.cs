using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    private ParticleSystem Fireflies;
    public Button NextLevelButton;
    public int WinPoints;
    private Scene ActiveScene;

    [System.Obsolete]
    private void Awake()
    {
        Fireflies = FindObjectOfType<ParticleSystem>();
        Fireflies.Play();
        SoundManager.Instance.Play(SoundEvents.PlayerWin);
        NextLevelButton.onClick.AddListener(NextLevel);
        ActiveScene = SceneManager.GetActiveScene();
        if (ActiveScene.buildIndex >= 5)
        {
            NextLevelButton.gameObject.SetActive(false);
        }
    }

    private void NextLevel()
    {
        if (ActiveScene.buildIndex < 5)
        {
            SoundManager.Instance.Play(SoundEvents.ButtonClick);
            SceneManager.LoadScene(ActiveScene.buildIndex + 1);
        }
    }

    public void PlayerWin()
    {
        Level_Manager.Instance.LevelComplete();
        gameObject.SetActive(true);
    }
}
