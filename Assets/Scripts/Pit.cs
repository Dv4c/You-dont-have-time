using System;
using Unity.VisualScripting;
using UnityEngine;

public class Pit : MonoBehaviour
{
    [SerializeField] private bool isExit;
  
    [SerializeField] private Main _main;
    public event Action Exited;
    
    public void Init(Main main)
    {
        _main = main;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<MainHero>() && isExit)
        {

            Exited?.Invoke();
        }
        else
        {
            _main.RestartGame();
        }
    }
}
