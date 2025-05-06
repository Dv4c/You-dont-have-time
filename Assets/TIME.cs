using System;
using System.Collections;
using UnityEngine;

public class TIME : MonoBehaviour
{
    [SerializeField] private float time; 
    [SerializeField] private Animator animator;
    public static event Action<TIME> OnTimeElapsed;
    
    
    private void Start()
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
            OnTimeElapsed?.Invoke(this);
        }
    }
    
    public void TimeStart()
    {
        animator.speed = 2f / time;
        animator.SetTrigger("t");
        animator.Play("Time", -1, 0f);
    }
}
