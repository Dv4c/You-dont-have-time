using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "NewLevel", order = 1)]
public class NextLevelData : ScriptableObject
{
    public float Duration;
    public float WaitNext;
}