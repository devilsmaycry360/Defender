using System;
using UnityEngine;

[Serializable]
public struct EnemyProbability
{
    public float Chance;
    public EnemyType Type;
    public GameObject Prefab;
}