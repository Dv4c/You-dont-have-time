using UnityEngine;

[CreateAssetMenu(fileName = "SoundsData", menuName = "Scriptable Objects/SoundsData")]
public class SoundsData : ScriptableObject
{
    public AudioClip Jump;
    public AudioClip Restart;
    public AudioClip Shake;
    public AudioClip PickUpKey;
    public AudioClip PickUpTime;
    public AudioClip Write;
    public AudioClip Click;
}
