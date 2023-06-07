using System;
using UnityEngine;

[Serializable]
public struct RewardProbability
{
    public float Chance;
    public RewardType Type;
    public GameObject Prefab;
}
