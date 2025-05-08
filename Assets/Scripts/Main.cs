using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPos;
    [Header("Sounds")]
    [SerializeField] private SoundsData sounds;
    [SerializeField] private AudioSource audioSource;
    
    [Header("Roots")]
    
    [SerializeField] private MainHero _player;
    [SerializeField] private Level _level;
    [SerializeField] private Exit _exit;
    [SerializeField] private TIME _time;
    [SerializeField] private Key _key;
    [SerializeField] private Timer _timer;
    [SerializeField] private Pit _pit;
    [SerializeField] private MusicPlayer _musicPlayer;
    [Header("Views")]
    [SerializeField] private NextLevelView _nextLevelView;
    [SerializeField] private StartContentView _startContentView;

    private StarterTime _starterTime;
    private NextLevelController _levelController;
    private AudioSystem audioSystem;
    private StartContent _startContent;

    private void Start()
    {
        _player.Disable();
        _time.TimeElapsed += OnTimerElapsed;
        audioSystem = new(audioSource, sounds);
        G.Audio = audioSystem;
        
        _level?.Init();       
        _startContent = new StartContent(this, _startContentView);
        _starterTime = new StarterTime(this, _player);
        _starterTime.Started += InitTime;
        
        _levelController = new NextLevelController(this, _level, _exit, _pit, _player, _nextLevelView);
        _levelController.Init();

        _exit?.Init(_level, _time, _key);
        _pit?.Init(_level);

        if (Level.WasReloaded == false && _startContentView != null)
        {
            _startContent.Started += StartContent;
            _startContent.Init();
        }
        else
        {
            StartContent();
        }
    }
    
    private void StartContent()
    {
        _musicPlayer.Init();
        _starterTime.Init();
        _player.Enable();
        _level?.Load();
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
    
    private void OnDisable()
    {
        _time.TimeElapsed -= OnTimerElapsed;
        _starterTime.Started -= InitTime;
        _levelController.Dispose();
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
    
    [ContextMenu("ClearStatic")]
    private void ClearStatic()
    {
        _level.Reset();
    }
}

public static class G
{
    public static AudioSystem Audio;
}