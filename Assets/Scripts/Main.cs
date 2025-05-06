using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 spawnPos;
    
    [Header("Roots")]
    [SerializeField] private Level _level;
    [SerializeField] private Exit _exit;
    [SerializeField] private TIME _time;

    private void Start()
    {
        _time.TimeElapsed += OnTimerElapsed;
        _time.Init();
        _level.Init();
        _exit.Init(_level, _time);
        player.transform.position = spawnPos;
    }

    private void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
#endif
}

    private void OnTimerElapsed(TIME time)
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}