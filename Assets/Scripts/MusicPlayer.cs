using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private MusicObject _prefab;
    
    private void Start()
    {
        MusicObject musicObject = FindObjectOfType<MusicObject>();

        if (musicObject == null)
        {
            MusicObject music = Instantiate(_prefab);
            music.Play();
            
            DontDestroyOnLoad(music);
        }
    }
}