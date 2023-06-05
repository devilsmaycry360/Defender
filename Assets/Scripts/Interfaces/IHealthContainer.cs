using System;
using UnityEngine;

public interface IHealthContainer
{
    int MaxHealth { get; }
    int CurrentHealth { get; }
    Action OnDeath { get; set; }
    Action OnHealthChanged { get; set; }

    public void ChangeHealth(int amount);
}
