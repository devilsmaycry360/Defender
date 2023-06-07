using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class RandomEnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyPool[] enemyPools;
    private Coroutine enemyGenerationCoroutine;
    private EnemyPool activeEnemyPool;

    private Action ChangeEnemyPoolAction => SetActivePool;
    
    private enum Direction
    {
        Left,
        Right
    }

    private void OnEnable()
    {
        activeEnemyPool = enemyPools[0];
        DifficultySystem.OnDifficultyChanged += ChangeEnemyPoolAction;
        enemyGenerationCoroutine = StartCoroutine(TryGeneratingEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(enemyGenerationCoroutine);
        DifficultySystem.OnDifficultyChanged -= ChangeEnemyPoolAction;
    }

    private IEnumerator TryGeneratingEnemy()
    {
        yield return new WaitForSeconds(activeEnemyPool.GenerationInterval);

        if (Random.Range(0.0f, 1.0f) <= activeEnemyPool.IntervalProbability)
            SpawnEnemyRandomlyOutsideOfScreen();

        enemyGenerationCoroutine = StartCoroutine(TryGeneratingEnemy());
    }

    private void SpawnEnemyRandomlyOutsideOfScreen()
    {
        Vector2 position;
        GameObject chosenEnemy = ChooseEnemy(activeEnemyPool);

        switch (FindSpawnDirection())
        {
            case Direction.Right:
                position = PositionConvertor.ViewportToWorldVector2(new Vector2(1.2f, Random.Range(0.2f, 0.8f)));
                Instantiate(chosenEnemy, position, Quaternion.Euler(0, 180, 0));
                break;
            case Direction.Left:
                position = PositionConvertor.ViewportToWorldVector2(new Vector2(-0.2f, Random.Range(0.2f, 0.8f)));
                Instantiate(chosenEnemy, position, Quaternion.Euler(0, 0, 0));
                break;
            default:
                break;
        }
    }

    public static GameObject ChooseEnemy(EnemyPool pool)
    {
        float totalWeight = 0;
        float weightCheck = 0;
        GameObject chosenEnemy = null;
        
        foreach (EnemyProbability enemy in pool.PossibleEnemies)
            totalWeight += enemy.Chance;

        float randomWeight = Random.Range(0, totalWeight);

        foreach (EnemyProbability enemy in pool.PossibleEnemies)
        {
            weightCheck += enemy.Chance;
            
            if (randomWeight > weightCheck)
                continue;

            chosenEnemy = enemy.Prefab;
            break;
        }

        return chosenEnemy;
    }
    
    private Direction FindSpawnDirection()
    {
        float pointerOffsetFromCenter = InputManager.PointerViewportPosition.x - 0.5f;

        if (pointerOffsetFromCenter >= 0)
            return Direction.Right;

        return Direction.Left;
    }

    private void SetActivePool()
    {
        activeEnemyPool = enemyPools[(int)DifficultySystem.CurrentDifficulty];
    }
}
