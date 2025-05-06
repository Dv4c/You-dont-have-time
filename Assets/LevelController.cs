using UnityEngine;
using UltEvents;
public class LevelController : MonoBehaviour
{
    public GameObject key;
    public Exit door;

    private void OnEnable()
    {
        Key.OnKeyDisabled += OnKeyCollected;
    }

    private void OnDisable()
    {
        Key.OnKeyDisabled -= OnKeyCollected;
    }

    private void OnKeyCollected(Key disabledKey)
    {
        if (disabledKey.gameObject == key)
        {
            door.Open();
        }
    }
    
    
}
