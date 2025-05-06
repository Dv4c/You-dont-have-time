using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _maxScenes;

    public int MaxScenes => _maxScenes;
}