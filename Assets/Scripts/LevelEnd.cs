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
        if (ActiveScene.buildIndex >= 5)
        {
            NextLevelButton.gameObject.SetActive(false);
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
        LevelManager.Instance.LevelComplete();
        gameObject.SetActive(true);
    }
}
