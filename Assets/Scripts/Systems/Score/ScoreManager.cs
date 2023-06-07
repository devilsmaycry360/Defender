using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int TotalScore => totalScore;
    private static int totalScore;

    public static void AddScore(int score)
    {
        totalScore += score;
        print("Score: " + totalScore);
    }

    private void OnEnable()
    {
        totalScore = 0;
    }
}
