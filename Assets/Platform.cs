using System;
using UnityEngine;
using DG.Tweening;
public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.DOShakePosition(
            duration: 0.1f,
            strength: new Vector3(0, 0.01f, 0), // вверх-вниз
            vibrato: 1,
            randomness: 0,
            snapping: false,
            fadeOut: true
        );
    }
}
