using UnityEngine;

public class Collectable_Coin : MonoBehaviour, IScoreContainer
{
    public int Score => score;
    [SerializeField] private int score;
    
    private void AddToScore()
    {
        ScoreManager.AddScore(score);
    }
    
    private void AddToCoins()
    {
        PlayerResources.AddCoins(1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        AddToScore();
        AddToCoins();
        Destroy(gameObject);
    }
}
