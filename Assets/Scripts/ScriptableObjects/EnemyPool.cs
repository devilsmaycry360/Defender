using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPool", menuName = "ScriptableObjects/EnemyPool")]
public class EnemyPool : ScriptableObject
{
    public float GenerationInterval;
    public float IntervalProbability;
    public EnemyProbability[] PossibleEnemies;
}
