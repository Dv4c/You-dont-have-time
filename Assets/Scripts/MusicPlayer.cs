using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private MusicObject _prefab;
    
    public void Init()
    {
        MusicObject[] musicObject = FindObjectsByType<MusicObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        if (musicObject.Length <= 0)
        {
            MusicObject music = Instantiate(_prefab);
            music.Play();
            
            DontDestroyOnLoad(music);
        }
    }
}