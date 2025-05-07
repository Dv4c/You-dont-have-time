using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class NextLevelView
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private NextLevelData _nextLevelData;
    
    private float _duration;
    private float _waitNext;

    private Transform Image => _image.transform;

    public void Init()
    {
        _duration = _nextLevelData.Duration;
        _waitNext = _nextLevelData.WaitNext;
    }
    
    public IEnumerator PlayEndLevel()
    {
        yield return Image.DOMoveX(_secondPoint.position.x, _duration).WaitForCompletion();
    }
    
    public IEnumerator PlayStartLevel()
    {
        Image.position = _secondPoint.position;
        yield return new WaitForSeconds(_waitNext);
        yield return Image.DOMoveX(_firstPoint.position.x, _duration).WaitForCompletion();
    }

    public IEnumerator PlayEndGame()
    {
        yield break;
    }

    public void Enable()
    {
        _image.enabled = true;
    }
}