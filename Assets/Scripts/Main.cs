using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
    [Header("Views")]
    [SerializeField] private NextLevelView _nextLevelView;
    [SerializeField] private IntroView introView;
    [SerializeField] private MusicPlayer _musicPlayer;

    private StarterTime _starterTime;
    private NextLevelController _levelController;
    private AudioSystem audioSystem;
    private IntroController _introController;
    
    private void Start()
    {
        _time.TimeElapsed += OnTimerElapsed;
        _player.Disable();
        
        audioSystem = new(audioSource, sounds);
        G.Audio = audioSystem;
        
        _level?.Init();
        
        _levelController = new NextLevelController(this, _level, _exit, _pit, _player, _nextLevelView);
        _levelController.Init();

        _exit?.Init(_level, _time, _key);
        _pit?.Init(_level);
        
        _starterTime = new StarterTime(this, _player);
        _starterTime.Started += InitTime;

        if (introView != null)
            _introController = new(introView);
        
        StartContent startContent = new StartContent(this, _introController, _player, _starterTime, _level, _musicPlayer);
        startContent.Init();
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

    [ContextMenu("ResetStatic")]
    private void ResetStatic()
    {
        _level.Reset();
    }
}

public static class G
{
    
    public static AudioSystem Audio;
    
}

public class StartContent
{
    private MonoBehaviour _behaviour;
    private IntroController _introController;
    private MainHero _player;
    private StarterTime _starterTime;
    private Level _level;
    private MusicPlayer _musicPlayer;

    public StartContent(MonoBehaviour monoBehaviour, IntroController introController, MainHero player,
        StarterTime starterTime, Level level, MusicPlayer musicPlayer)
    {
        _behaviour = monoBehaviour;
        
        if (introController != null)
            _introController = introController;
        
        _player = player;
        _starterTime = starterTime;
        _level = level;
        _musicPlayer = musicPlayer;
    }

    public void Init()
    {
        _behaviour.StartCoroutine(Start());
    }

    private IEnumerator Start()
    {
        if (_introController != null)
        {
            if (Level.WasRelaoded == false)
            {
                yield return _introController.StartIntro();
                _musicPlayer.Init();
                _player.Enable();
            }
        }

        _starterTime.Init();
        _musicPlayer.Init();
        _level.Load();
    }
}