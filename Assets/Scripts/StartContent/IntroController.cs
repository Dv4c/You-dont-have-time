using System;
using System.Collections;
using UnityEngine;

public class IntroController
{
    private IntroView _view;

    public event Action Started;
    
    public IntroController(IntroView introView)
    {
        _view = introView;
    }
    
    public IEnumerator StartIntro()
    {
        yield return ShowIntro();
        yield return HideText();
        
        yield return new WaitForSeconds(0.5f);
        yield return _view.HideBackground();
        Started?.Invoke();
    }

    private IEnumerator ShowIntro()
    {
        _view.Enable();
        yield return new WaitForSeconds(0.5f);
        _view.StartWrite();
        _view.Shake();
    }
    
    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);
        G.Audio.Play(G.Audio.Sounds.Click);
        _view.Shake();
        yield return _view.HideText();
    }
}