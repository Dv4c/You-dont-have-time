using System;
using System.Collections;
using UnityEngine;

public class StarterTime
{
    private MainHero _player;
    private MonoBehaviour _monoBehaviour;
    
    public event Action Started; 
    
    public StarterTime(MonoBehaviour monoBehaviour, MainHero player)
    {
        _monoBehaviour = monoBehaviour;
        _player = player;
    }

    public void Init()
    {
        _monoBehaviour.StartCoroutine(Start());
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