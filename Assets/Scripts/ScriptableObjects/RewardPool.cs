using UnityEngine;

[CreateAssetMenu(fileName = "RewardPool", menuName = "ScriptableObjects/RewardPool")]
public class RewardPool : ScriptableObject
{
    public RewardProbability[] PossibleRewards;
}
