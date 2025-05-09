using System.Collections;
using JetBrains.Annotations;
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
        
        if (pit != null)
            _pit = pit;
        
        _player = player;
        _nextLevelView = nextLevelView;
    }

    public void Init()
    {
        _nextLevelView.Init();
        _exit.Exited += OnExited;
        
        if (_pit != null)
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
        if (_level.IsFirstLevel && Level.WasRelaoded == false)
        {
            Debug.Log("Moew");
            yield break;
        }
        
        if (_level.IsLevelCompleted)
            _nextLevelView.SetSprite(_nextLevelView.LevelCompletedSprite);
        else
            _nextLevelView.SetSprite(_nextLevelView.LevelFailedSprite);
        
        if (_level.IsFirstLevel && Level.WasRelaoded)
        {
            _nextLevelView.SetSprite(_nextLevelView.LevelFailedSprite);
        }
        
        //_nextLevelView.Enable();
        _player.Disable();
        yield return _nextLevelView.LerpFromNext();
        _player.Enable();
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
        _nextLevelView.SetSprite(_nextLevelView.LevelCompletedSprite);
        yield return _nextLevelView.LerpToNext();
        _level.NextLevel(true);
    }
}