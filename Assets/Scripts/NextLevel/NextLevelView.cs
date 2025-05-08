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
    [SerializeField] private Transform _thirdPoint;
    [SerializeField] private NextLevelData _nextLevelData;
    
    private float _duration;
    private float _waitNext;

    private Transform Image => _image.transform;
    
    public Sprite LevelCompletedSprite { get; private set; }
    public Sprite LevelFailedSprite { get; private set; }

    public void Init()
    {
        _duration = _nextLevelData.Duration;
        _waitNext = _nextLevelData.WaitNext;
        LevelCompletedSprite = _nextLevelData.LevelCompletedSprite;
        LevelFailedSprite = _nextLevelData.LevelFailedSprite;
    }
    
    public IEnumerator LerpToNext()
    {
        Image.position = _firstPoint.position;
        yield return Image.DOMoveX(_secondPoint.position.x, _duration).WaitForCompletion();
    }
    
    public IEnumerator LerpFromNext()
    {
        Debug.Log("LerpFromNext");
        Image.position = _secondPoint.position;
        yield return new WaitForSeconds(_waitNext);
        yield return Image.DOMoveX(_thirdPoint.position.x, _duration).WaitForCompletion();
    }

    public IEnumerator PlayEndGame()
    {
        yield break;
    }

    public void Enable()
    {
        _image.enabled = true;
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}