using UnityEngine;

[CreateAssetMenu(fileName = "LevelStructure", menuName = "ScriptableObjects/LevelStructure")]
public class LevelStructure : ScriptableObject
{
    public LevelTile[] LevelTileOrder;
}
