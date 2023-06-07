using UnityEngine;

public class Collectable_BulletPowerup : MonoBehaviour, IScoreContainer
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

        other.gameObject.GetComponent<PlayerShooting>().LevelUpBullet();
        
        AddToScore();
        Destroy(gameObject);
    }
}
