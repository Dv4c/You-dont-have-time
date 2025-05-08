using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class StartContent
{
    private StartContentView _view;
    private MonoBehaviour _behaviour;

    public event Action Started;
    
    public StartContent(MonoBehaviour monoBehaviour, StartContentView startContentView)
    {
        _behaviour = monoBehaviour;
        _view = startContentView;
    }

    public void Init()
    {
        _behaviour.StartCoroutine(Start());
    }
    
    private IEnumerator Start()
    {
        _view.Enable();
        yield return new WaitForSeconds(0.5f);
        _view.StartWrite();
        _view.Shake();
        
        yield return new WaitForSeconds(2f);
        G.Audio.Play(G.Audio.Sounds.Click);
        _view.Shake();
        
        yield return _view.HideText();
        //_view.StopWrite();
        
        _view.Image.DOFade(0, 0.5f).SetEase(Ease.Linear);
        Started?.Invoke();
    }
}
