using System;
using System.Collections;
using UnityEngine;

public class StarterTime
{
    private MainHero _player;
    
    public event Action Started; 
    
    public StarterTime Init(MonoBehaviour monoBehaviour, MainHero player)
    {
        monoBehaviour.StartCoroutine(Start());
        _player = player;
        return this;
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