using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = Level_Manager.Instance.GetLevelStatus(LevelName);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(SoundEvents.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.Play(SoundEvents.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;

        }
    }
}
