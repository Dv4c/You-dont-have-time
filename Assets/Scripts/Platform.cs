
using UnityEngine;
using DG.Tweening;


public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject chains;
    [SerializeField] private GameObject board;
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        chains.transform.DOShakePosition(
            duration: 0.05f,
            strength: new Vector3(0, 0.01f, 0), // вверх-вниз
            vibrato: 1,
            randomness: 0,
            snapping: false,
            fadeOut: true
        );
        board.transform.DOShakePosition(
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
            mainHero.transform.SetParent(null);
        }
    }
}
