using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthContainer
{
    public static bool PlayerIsDead;
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public Action OnHealthIncrease;
    public Action OnHealthDecrease;
    public Action OnDeath { get; set; }
    public Action OnHealthChanged { get; set; }

    [SerializeField] private int maxHealth;
    
    private int currentHealth;
    private Action onCollisionAction;

    private void OnEnable()
    {
        PlayerIsDead = false;
        currentHealth = maxHealth;
        OnDeath += SetPlayerAsDead;
        onCollisionAction = () => ChangeHealth(-1);
        PlayerCollision.OnPlayerCollision += onCollisionAction;
    }
    
    private void OnDisable()
    {
        OnDeath -= SetPlayerAsDead;
        PlayerCollision.OnPlayerCollision -= onCollisionAction;
    }

    public void ChangeHealth(int amount)
    {
        if (amount == 0)
            return;
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke();
        
        if (amount > 0)
            OnHealthIncrease?.Invoke();
        else
            OnHealthDecrease?.Invoke();

        if (currentHealth == 0)
            OnDeath?.Invoke();
    }

    private static void SetPlayerAsDead()
    {
        PlayerIsDead = true;
    }
}
