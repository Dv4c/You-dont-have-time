using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicObject : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _musicClip;

    public void Play()
    {
        _audioSource.clip = _musicClip;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}