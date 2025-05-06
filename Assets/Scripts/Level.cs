using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Level
{
    [SerializeField] private LevelData _level;
    
    private int _indexCurrentScene;
    private int _maxScenes;

    private int _indexNextScene => _indexCurrentScene + 1;

    public void Init()
    {
        _indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
        _maxScenes = _level.MaxScenes;
    }

    public void NextLevel()
    {
        if (_indexCurrentScene == _maxScenes)
        {
            Debug.Log("All levels complete");
            return;
        }

        SceneManager.LoadScene(_indexNextScene);
    }
}