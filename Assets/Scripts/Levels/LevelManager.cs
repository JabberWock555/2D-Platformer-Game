using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string[] Levels;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(GetLevelStatus(Levels[1]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            SetLevelStatus(Levels[1], LevelStatus.Unlocked);
        }
    }

    public void LevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
        int currentLevelIndex = Array.FindIndex(Levels, level => level == SceneManager.GetActiveScene().name);
        int nextLevelIndex = currentLevelIndex + 1;
        SetLevelStatus(Levels[nextLevelIndex], LevelStatus.Unlocked);
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
