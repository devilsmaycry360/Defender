using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthContainer
{
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public Action OnDeath { get; set; }
    public Action OnHealthChanged { get; set; }

    [SerializeField] private int maxHealth;
    
    private int currentHealth;
    private Action onCollisionAction;

    private void OnEnable()
    {
        currentHealth = maxHealth;
        onCollisionAction = () => ChangeHealth(-1);
        PlayerCollision.OnPlayerCollision += onCollisionAction;
    }
    
    private void OnDisable()
    {
        PlayerCollision.OnPlayerCollision -= onCollisionAction;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke();

        if (currentHealth == 0)
            OnDeath?.Invoke();
    }
}
