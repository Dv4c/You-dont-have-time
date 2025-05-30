using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time; 
    [SerializeField] private Animator animator;

    public event Action<float> Taken;
    
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
    }
    
    public void TimeStart()
    {
        animator.speed = 2f / time;
        animator.SetTrigger("t");
        animator.Play("Time", -1, 0f);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MainHero mainHero))
        {
            G.Audio.Play(G.Audio.Sounds.PickUpTime,0.05f);
            transform.DOScale(Vector3.zero, 0.1f);
            this.gameObject.SetActive(false); 
            //Taken?.Invoke(time * 1.5f);
            Taken?.Invoke(time); // пока так
        } 
    }
}