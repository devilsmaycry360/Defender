using System;
using UnityEngine;

public class LevelTile : MonoBehaviour
{
    public Transform EntryPoint => entryPoint;
    public Transform ExitPoint => exitPoint;
    
    [SerializeField] private Transform entryPoint;
    [SerializeField] private Transform exitPoint;

    public Action onDestroyAction;

    private void OnDestroy()
    {
        onDestroyAction?.Invoke();
    }
}
