using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time; 
    [SerializeField] private Animator animator;
    
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
    }
    
    public void TimeStart()
    {
        
        animator.speed = 2f / time;
        animator.SetTrigger("t");
        animator.Play("Time", -1, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out MainHero mainHero))
        {
            transform.DOScale(Vector3.zero, 0.1f);
            Debug.Log(mainHero);
            this.enabled = false;
        }
    }

    
}