using System;
using DG.Tweening;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static event Action<Key> OnKeyDisabled;
    public bool IsTaken { get; private set; }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MainHero mainHero))
        {
            transform.DOScale(Vector3.zero, 0.1f);
            Debug.Log(mainHero);
            IsTaken = true;
            this.enabled = false;
        } 
    }
    

    private void OnDisable()
    {
        OnKeyDisabled?.Invoke(this);
    }
}
