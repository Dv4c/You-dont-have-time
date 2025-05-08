using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Level
{
    private const string LevelCompleted = nameof(LevelCompleted);
    
    [SerializeField] private LevelData _level;
    
    private int _indexCurrentScene;
    private int _maxScenes;

    private int _indexNextScene => _indexCurrentScene + 1;
    public bool IsLastLevel => _indexCurrentScene == _maxScenes;
    public bool IsFirstLevel => _indexCurrentScene == 0;
    public bool IsLevelCompleted => PlayerPrefs.GetInt(LevelCompleted) == 1;
    public static bool WasReloaded { get; private set; } = false;

    public void Init()
    {
        _indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
        _maxScenes = _level.MaxScenes;
        
        if (WasReloaded)
        {
            Debug.Log("Сцена была перезагружена!");
        }
        else
        {
            WasReloaded = true;
            Debug.Log("Первая загрузка сцены.");
        }
    }

    public void NextLevel(bool isComplete)
    {
        if (_indexCurrentScene == _maxScenes)
        {
            Debug.Log("All levels complete");
            return;
        }

        int complete = isComplete ? 1 : 0;
        PlayerPrefs.SetInt(LevelCompleted, complete);
        PlayerPrefs.Save();
        
        SceneManager.LoadScene(_indexNextScene);
    }

    public void LevelFaile()
    {
        PlayerPrefs.SetInt(LevelCompleted, 0);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        WasReloaded = false;
    }
}