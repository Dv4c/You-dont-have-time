using System;
using Unity.VisualScripting;
using UnityEngine;

public class Pit : MonoBehaviour
{
    [SerializeField] private bool isExit;
    private Level _level;

    public event Action Exited;
    
    public void Init(Level level)
    {
        _level = level;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<MainHero>() && isExit)
        {
            //_level.NextLevel();
            Exited?.Invoke();
        }
    }
}
