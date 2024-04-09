using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "Project/LevelsData", order = 0)]
    public class LevelsData : ScriptableObject
    {
        [field: SerializeField] public int LevelCount { get; private set; }
                
    }
}