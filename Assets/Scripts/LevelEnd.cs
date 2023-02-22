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
