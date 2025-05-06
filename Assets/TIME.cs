using System;
using System.Collections;
using UnityEngine;

public class TIME : MonoBehaviour
{
    [SerializeField] private float time; 
    [SerializeField] private Animator animator;
    public event Action<TIME> TimeElapsed;
    public bool Ended { get; private set; } = false;
    
    public void Init()
    {
        TimeStart();
        StartCoroutine(Subtract());
    }

    IEnumerator Subtract()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        if (time == 0f)
        {
            TimeElapsed?.Invoke(this);
            Ended = true;
        }
    }
    
    public void TimeStart()
    {
        animator.speed = 2f / time;
        animator.SetTrigger("t");
        animator.Play("Time", -1, 0f);
    }
}
