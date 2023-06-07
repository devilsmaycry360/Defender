using System;
using UnityEngine;
using System.Collections;

public class DifficultySystem : MonoBehaviour
{
    public static Action OnDifficultyChanged;
    public static Difficulty CurrentDifficulty => currentDifficulty;
    
    private static Difficulty currentDifficulty;
    
    [SerializeField] private int[] difficultiesTimeLimit;

    private int timer;
    
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    private void Update()
    {
        print(currentDifficulty);
    }

    private void OnEnable()
    {
        currentDifficulty = Difficulty.Easy;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timer++;
        CheckDifficultyIncrease();
        
        if (currentDifficulty != Difficulty.Hard)
            StartCoroutine(Timer());
    }

    private void CheckDifficultyIncrease()
    {
        if (timer >= difficultiesTimeLimit[(int) currentDifficulty])
            IncreaseDifficulty();
    }

    private void IncreaseDifficulty()
    {
        if (currentDifficulty == Difficulty.Hard)
            return;
        
        currentDifficulty++;
        OnDifficultyChanged?.Invoke();
    }
}
