using System;
using UnityEngine;

public class Exit : MonoBehaviour
{   
    [SerializeField] private GameObject openBackground;
    [SerializeField] private GameObject openFront;
    [SerializeField] private GameObject close;
    [SerializeField] private GameObject Trigger;

    private Level _level;
    private TIME _time;
    private bool isOpen;
    
    public void Init(Level level, TIME time)
    {
        _level = level;
        _time = time;
        isOpen = false;
        switchState(ref isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (_time.Ended)
        {
            Debug.Log("TIME is end");
            return;
        }
        
        if (other.GetComponent<MainHero>())
        {
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
        Trigger.SetActive(state);
        close.SetActive(!state);
        state = !state;
    }
}
