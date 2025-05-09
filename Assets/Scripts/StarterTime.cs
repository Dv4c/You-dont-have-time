using System;
using System.Collections;
using UnityEngine;

public class StarterTime
{
    private MonoBehaviour _mono;
    private MainHero _player;
    
    public event Action Started; 
    
    public StarterTime(MonoBehaviour monoBehaviour, MainHero player)
    {
        _mono = monoBehaviour;
        _player = player;
    }

    public void Init()
    {
        _mono.StartCoroutine(Start());
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (_player.IsPlayerMoved())
                break;
            
            yield return null;
        }

        Started?.Invoke();
    }
}