using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPos;

    [Header("Roots")] 
    [SerializeField] private MainHero _player;
    [SerializeField] private Level _level;
    [SerializeField] private Exit _exit;
    [SerializeField] private TIME _time;
    [SerializeField] private Key _key;
    [SerializeField] private Timer _timer;
    [SerializeField] private Pit _pit;
    
    [Header("Views")]
    [SerializeField] private NextLevelView _nextLevelView;

    private StarterTime _starterTime;
    private NextLevelController _levelController;
    
    private void Start()
    {
        _time.TimeElapsed += OnTimerElapsed;
        _starterTime = new StarterTime();
        _starterTime.Init(this, _player).Started += InitTime;
        
        _level?.Init();
        
        _levelController = new NextLevelController(this, _level, _exit, _pit, _player, _nextLevelView);
        _levelController.Init();

        _exit?.Init(_level, _time, _key);
        _pit?.Init(_level);
        player.transform.position = spawnPos.transform.position;
    }

    private void OnDisable()
    {
        _time.TimeElapsed -= OnTimerElapsed;
        _starterTime.Started -= InitTime;
        _levelController.Dispose();
    }

    private void InitTime()
    {
        _timer?.Init();
        _time?.Init(_timer);
    }

    private void Update()
    {
    #if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    #endif
    }

    private void OnTimerElapsed(TIME time)
    {
        if (_levelController.IsStarted)
            return;
        
        RestartGame();
    }

    private void RestartGame()
    {
        _level.LevelFaile();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}