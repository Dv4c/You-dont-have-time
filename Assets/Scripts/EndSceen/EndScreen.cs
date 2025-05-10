using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private NextLevelView _nextLevelView;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SoundsData _soundsData;
    
    private AudioSystem _audioSystem;
    
    private IEnumerator Start()
    {
        _audioSystem = new AudioSystem(_audioSource, _soundsData);
        _nextLevelView.Init();
        _nextLevelView.SetSprite(_nextLevelView.LevelCompletedSprite);
        yield return _nextLevelView.LerpFromNext();
        _audioSystem.Play(_audioSystem.Sounds.Win);
    }

    private void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
#endif
    }
}
