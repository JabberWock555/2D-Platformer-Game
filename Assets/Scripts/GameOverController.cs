using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    private ParticleSystem Fireflies;

    [System.Obsolete]
    private void Awake()
    {
        Fireflies = FindObjectOfType<ParticleSystem>();
        var colorOverLifetime = Fireflies.colorOverLifetime;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.red, 0.5f) },
             new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
        Fireflies.Play();
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
