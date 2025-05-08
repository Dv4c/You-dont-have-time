
using UnityEngine;

public class AudioSystem
{
    
    private AudioSource _audioSource;
    private SoundsData _sounds;
    public SoundsData Sounds => _sounds;

    public AudioSystem(AudioSource audioSource,SoundsData sounds )
    {
        _audioSource = audioSource;
        _sounds = sounds;
    }
    
    public void Play(AudioClip audioClip, float volume = 1f)
    {
        _audioSource.PlayOneShot(audioClip, volume);
    }
}
