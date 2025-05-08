using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "NewLevel", order = 1)]
public class NextLevelData : ScriptableObject
{
    [field: SerializeField] public Sprite LevelCompletedSprite { get; private set; }
    [field: SerializeField] public Sprite LevelFailedSprite { get; private set; }
    
    public float Duration;
    public float WaitNext;
}