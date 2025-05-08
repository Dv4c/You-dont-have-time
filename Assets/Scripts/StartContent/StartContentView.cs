using System;
using DG.Tweening;
using Febucci.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class StartContentView
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextAnimator _textAnimator;
    [SerializeField] private TextAnimatorPlayer _player;
    [SerializeField] private Transform _transform;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    
    public void Enable()
    {
        _canvas.SetActive(true);
    }

    public void StartWrite()
    {
        _player.ShowText("GAME BY DVAC");
        _player.StartShowingText();
    }

    public void Shake()
    {
        _transform.DOShakePosition(0.2f, 15, 50);
    }
}