using System;
using UnityEngine;

public class Astroid : MonoBehaviour, IHealthContainer
{
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public Action OnDeath { get; set; }
    public Action OnHealthChanged { get; set; }
    
    [SerializeField] private int maxHealth;
    
    private int currentHealth;
    private Action destroyAction => DestroyThis;

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke();

        if (currentHealth == 0)
            OnDeath?.Invoke();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        
        OnDeath += destroyAction;
    }

    private void OnDisable()
    {
        OnDeath -= destroyAction;
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
