using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPos;
    
    [Header("Roots")]
    [SerializeField] private Level _level;
    [SerializeField] private Exit _exit;
    [SerializeField] private TIME _time;
    [SerializeField] private Key _key;

    [SerializeField] private Timer _timer;
    
    [SerializeField] private Pit _pit;

    private void Start()
    {
        _time.TimeElapsed += OnTimerElapsed;
        _timer?.Init();
        _time?.Init(_timer);
        _level?.Init();
        _exit?.Init(_level, _time, _key);
        _pit?.Init(_level);
        player.transform.position = spawnPos.transform.position;
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