using System.Collections;
using UnityEngine;

public class StartContentController
{
    private StartContentView _view;
    
    public StartContentController(StartContentView startContentView)
    {
        _view = startContentView;
    }

    public void Init(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(StartIntro());
    }

    private IEnumerator StartIntro()
    {
        yield return ShowIntro();
    }

    public IEnumerator ShowIntro()
    {
        _view.Enable();
        yield return new WaitForSeconds(0.5f);
        _view.StartWrite();
        _view.Shake();
    }
}