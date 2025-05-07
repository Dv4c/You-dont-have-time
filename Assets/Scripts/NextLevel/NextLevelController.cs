using System.Collections;
using UnityEngine;

public class NextLevelController
{
    private MonoBehaviour _behaviour;
    private Level _level;
    private Exit _exit;
    private Pit _pit;
    private MainHero _player;
    private NextLevelView _nextLevelView;
    
    public bool IsStarted { get; private set; } = false;

    public NextLevelController(MonoBehaviour monoBehaviour, Level level, Exit exit, Pit pit,
        MainHero player, NextLevelView nextLevelView)
    {
        _behaviour = monoBehaviour;
        _level = level;
        _exit = exit;
        _pit = pit;
        _player = player;
        _nextLevelView = nextLevelView;
    }

    public void Init()
    {
        _nextLevelView.Init();
        _exit.Exited += OnExited;
        _pit.Exited += OnExited;
        _behaviour.StartCoroutine(StartRoutine());
    }

    public void Dispose()
    {
        _exit.Exited -= OnExited;
        _exit.Exited -= OnExited;
    }
    
    private void OnExited()
    {
        IsStarted = true;
        _behaviour.StartCoroutine(ExitedRoutine());
    }

    private IEnumerator StartRoutine()
    {
        if (_level.IsLastLevel || _level.IsFirstLevel)
        {
            Debug.Log("_level.IsLastLevel || _level.IsFirstLevel");
            yield break;
        }
            
        //_nextLevelView.Enable();
        Debug.Log("Player");
        yield return _nextLevelView.PlayStartLevel();
    }
    
    private IEnumerator ExitedRoutine()
    {
        _player.Disable();

        if (_level.IsLastLevel)
        {
            //StartAniamtionEndGame
            Debug.Log("//StartAniamtionEndGame");
            yield break;
        }

        yield return _nextLevelView.PlayEndLevel();
        _level.NextLevel();
    }
}