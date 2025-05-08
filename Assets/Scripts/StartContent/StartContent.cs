using System;
using System.Collections;
using UnityEngine;

public class StartContent
{
    private StartContentView _view;
    
    public StartContent(StartContentView startContentView)
    {
        _view = startContentView;
    }
    
    public IEnumerator OnEncounterReady()
    {
        _view.Enable();
        yield return new WaitForSeconds(0.5f);
        _view.StartWrite();
        _view.Shake();
        
        yield return new WaitForSeconds(3f);
        G.Audio.Play(G.Audio.Sounds.Click);
        _view.Shake();
        
        yield return _view.HideText();
        _view.StopWrite();
        
        yield return new WaitForSeconds(0.5f);
        _view.HideBackground();
        Debug.Log("EndOnEncounterReady");
    }
}
