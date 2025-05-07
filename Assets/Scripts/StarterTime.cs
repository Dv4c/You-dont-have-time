using System;
using System.Collections;
using UnityEngine;

public class StarterTime
{
    public event Action Started; 
    
    public StarterTime Init(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(Start());
        return this;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (IsPlayerMoved())
                break;
            
            yield return null;
        }

        Started?.Invoke();
    }

    private bool IsPlayerMoved()
    {
        return Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") > 0;
    }
}