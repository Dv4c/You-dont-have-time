using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private NextLevelView _nextLevelView;
    
    private IEnumerator Start()
    {
        _nextLevelView.Init();
        _nextLevelView.SetSprite(_nextLevelView.LevelCompletedSprite);
        yield return _nextLevelView.LerpFromNext();
    }

    private void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
#endif
    }
}
