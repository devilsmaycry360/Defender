using UnityEngine;

public class Collectable_Health : MonoBehaviour, IScoreContainer
{
    public int Score => score;
    [SerializeField] private int score;
    
    private void AddToScore()
    {
        ScoreManager.AddScore(score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        other.gameObject.GetComponent<IHealthContainer>().ChangeHealth(1);
        
        AddToScore();
        Destroy(gameObject);
    }
}
