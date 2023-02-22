using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        SoundManager.Instance.Play(SoundEvents.ButtonClick);
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex);
    }


}
