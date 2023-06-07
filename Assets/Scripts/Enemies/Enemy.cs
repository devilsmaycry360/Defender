using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IHealthContainer, IScoreContainer, IRewardContainer
{
    public int Score => score;
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public RewardPool PossibleRewards => possibleRewards;
    public Action OnDeath { get; set; }
    public Action OnHealthChanged { get; set; }
    
    [SerializeField] private int score;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject deathExplosion;
    [SerializeField] private RewardPool possibleRewards;
    
    private int currentHealth;
    private Action destroyAction => DestroyThis;
    private Action addScoreAction => AddToScore;
    private Action deathExplosionAction => PlayDeathExplosion;
    private Action checkRewardAction => CheckReward;

    public void ChangeHealth(int amount)
    {
        if (amount == 0)
            return;
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke();

        if (currentHealth == 0)
            OnDeath?.Invoke();
    }

    protected void OnEnable()
    {
        currentHealth = maxHealth;
        
        OnDeath += destroyAction;
        OnDeath += addScoreAction;
        OnDeath += deathExplosionAction;
        OnDeath += checkRewardAction;
    }

    protected void OnDisable()
    {
        OnDeath -= destroyAction;
        OnDeath -= addScoreAction;
        OnDeath -= deathExplosionAction;;
        OnDeath -= checkRewardAction;;
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void AddToScore()
    {
        ScoreManager.AddScore(score);
    }

    private void PlayDeathExplosion()
    {
        Instantiate(deathExplosion, transform.position, transform.rotation);
    }
    
    private void CheckReward()
    {
        RewardProbability reward = ((IRewardContainer)this).ChooseReward();
        
        if (reward.Type == RewardType.None)
            return;

        Instantiate(reward.Prefab, transform.position, transform.rotation);
    }
}
