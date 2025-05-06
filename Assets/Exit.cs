using System;
using UnityEngine;

public class Exit : MonoBehaviour
{   
    
    
    [SerializeField] private GameObject openBackground;
    [SerializeField] private GameObject openFront;
    [SerializeField] private GameObject close;
    [SerializeField] private GameObject Trigger;
    
    private bool isOpen;
    private void Awake()
    {
        isOpen = false;
        switchState(ref isOpen);
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
