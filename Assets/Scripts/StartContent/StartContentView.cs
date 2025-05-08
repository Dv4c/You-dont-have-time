using DG.Tweening;
using Febucci.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class StartContentView : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextAnimator _textAnimator;
    [SerializeField] private TextAnimatorPlayer _player;
    [SerializeField] private Transform _transform;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    
    public Image Image => _image;
    
    public void StartWrite()
    {
        _player.ShowText("GAME BY DVAC");
        _player.StartShowingText();
    }

    public void StopWrite()
    {
        _player.StopShowingText();
    }
    
    public void Shake()
    {
        _transform.DOShakePosition(0.2f, 15, 50);
    }
    
    public YieldInstruction HideText()
    {
        return _text.DOFade(0, 1f).WaitForCompletion();
    }

    public void TextSound()
    {
        G.Audio.Play(G.Audio.Sounds.Write);
    }

    public void Enable()
    {
        _canvas.SetActive(true);
    }
}