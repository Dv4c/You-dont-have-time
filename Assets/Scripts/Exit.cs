using System;
using UnityEngine;

public class Exit : MonoBehaviour
{   
    [SerializeField] private GameObject openBackground;
    [SerializeField] private GameObject openFront;
    [SerializeField] private GameObject close;
    [SerializeField] private BoxCollider2D Trigger;

    private Level _level;
    private TIME _time;
    private Key _key;
    private bool isOpen;
    
    public void Init(Level level, TIME time, Key key)
    {
        _level = level;
        _time = time;
        _key = key;
        isOpen = false;
        switchState(ref isOpen);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        if (_time.Ended || !_key.IsTaken)
        {
            return;
        }
        
        if (other.GetComponent<MainHero>())
        {
            Debug.Log("Next");
            _level.NextLevel();
        }
    }

    public void Open()
    {
        switchState(ref isOpen);
    }

    void switchState(ref bool state)
    {
        openBackground.SetActive(state);
        openFront.SetActive(state);
        Trigger.enabled = state;
        close.SetActive(!state);
        state = !state;
    }
}
