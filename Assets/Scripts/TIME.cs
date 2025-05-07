using System;
using System.Collections;
using UnityEngine;

public class TIME : MonoBehaviour
{
    [SerializeField] private float time; 
    [SerializeField] private Animator animator;
    
    private Timer _timer;
    
    public event Action<TIME> TimeElapsed;
    public bool Ended { get; private set; } = false;
    
    public void Init(Timer timer)
    {
        if (timer != null)
        {
            _timer = timer;
            _timer.Taken += OnTaken;    
        }
            
        
        TimeStart();
        StartCoroutine(Subtract());
    }

    private void OnDisable()
    {
        if (_timer != null)
        {
            _timer.Taken -= OnTaken;
            Debug.Log("OnTaken");
        }
    }

    private void OnTaken(float addTime)
    {
        if (addTime > 0.1f) //чтоб большое время не начиналось заново с большой скоростью
        {
            time += addTime;
            TimeStart();    
        }
        
    }

    IEnumerator Subtract()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);//Это хрень нужна чтобы анимация успела закончится
        TimeElapsed?.Invoke(this);
        Ended = true;
    }
    
    public void TimeStart()
    {
        animator.speed = 2f / time;
        animator.SetTrigger("t");
        animator.Play("Time", -1, 0f);
    }
}
