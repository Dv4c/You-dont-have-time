using System;
using DG.Tweening;
using UltEvents;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static event Action<Key> OnKeyDisabled;
    public UltEvent OnKeyUp;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MainHero mainHero))
        {
            transform.DOScale(Vector3.zero, 0.1f);
            Debug.Log(mainHero);
            this.enabled = false;
        } 
    }
    

    private void OnDisable()
    {
        OnKeyDisabled?.Invoke(this);
    }
}
