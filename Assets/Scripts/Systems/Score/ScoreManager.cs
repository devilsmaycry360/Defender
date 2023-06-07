using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int TotalScore => totalScore;
    public static Action OnScoreChanged;
    private static int totalScore;

    public static void AddScore(int score)
    {
        totalScore += score;
        OnScoreChanged?.Invoke();
    }

    private void OnEnable()
    {
        totalScore = 0;
    }
}
