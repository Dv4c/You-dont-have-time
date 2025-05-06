
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {

        transform.DOShakePosition(
            duration: 0.05f,
            strength: new Vector3(0, 0.01f, 0), // вверх-вниз
            vibrato: 1,
            randomness: 0,
            snapping: false,
            fadeOut: true
        );
    
        
        if (other.gameObject.TryGetComponent(out MainHero mainHero))
        {
            mainHero.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out MainHero mainHero))
        {
            mainHero.gameObject.transform.SetParent(null);
        }
    }
}
