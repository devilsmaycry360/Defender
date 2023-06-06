using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlowSystem : MonoBehaviour
{
    [SerializeField] private LevelStructure levelStructure;

    private LevelTile nextRightTile;
    private LevelTile nextLeftTile;
    private int lastRightIndex;
    private int lastLeftIndex;
    private List<LevelTile> spawnedTiles = new List<LevelTile>();

    private void OnEnable()
    {
        StartCoroutine(WaitAndInitializeLevel());
    }

    private void InitializeLevel()
    {
        Vector2 startPosition = PositionConvertor.ViewportToWorldVector2(new Vector2(0, 0.5f));
        startPosition = new Vector2(startPosition.x - levelStructure.LevelTileOrder[0].EntryPoint.localPosition.x, startPosition.y);
        LevelTile levelTile = Instantiate(levelStructure.LevelTileOrder[0], startPosition, transform.rotation).GetComponent<LevelTile>();
        spawnedTiles.Add(levelTile);
        levelTile.onDestroyAction += () =>
        {
            OnTileDestroy(levelTile);
        };

        lastRightIndex = 0;
        lastLeftIndex = 0;
        nextRightTile = FindNextRightTile();
        nextLeftTile = FindNextLeftTile();
    }

    private void FixedUpdate()
    {
        if (spawnedTiles.Count == 0)
            return;
        
        CheckLevelLimits();
    }

    private IEnumerator WaitAndInitializeLevel()
    {
        yield return new WaitForSeconds(0.1f);
        InitializeLevel();
    }

    private LevelTile FindNextRightTile()
    {
        lastRightIndex++;

        if (lastRightIndex >= levelStructure.LevelTileOrder.Length)
        {
            lastRightIndex = 0;
            return levelStructure.LevelTileOrder[0];
        }


        return levelStructure.LevelTileOrder[lastRightIndex];
    }
    
    private LevelTile ChangeNextRightTileOnDelete()
    {
        lastRightIndex--;

        if (lastRightIndex < 0)
        {
            lastRightIndex = levelStructure.LevelTileOrder.Length - 1;
            return levelStructure.LevelTileOrder[^1];
        }


        return levelStructure.LevelTileOrder[lastRightIndex];
    }
    
    private LevelTile FindNextLeftTile()
    {
        lastLeftIndex--;

        if (lastLeftIndex < 0)
        {
            lastLeftIndex = levelStructure.LevelTileOrder.Length - 1;
            return levelStructure.LevelTileOrder[^1];
        }

        
        return levelStructure.LevelTileOrder[lastLeftIndex];
    }
    
    private LevelTile ChangeNextLeftTileOnDelete()
    {
        lastLeftIndex++;

        if (lastLeftIndex >= levelStructure.LevelTileOrder.Length)
        {
            lastLeftIndex = 0;
            return levelStructure.LevelTileOrder[0];
        }

        
        return levelStructure.LevelTileOrder[lastLeftIndex];
    }

    private void CheckLevelLimits()
    {
        CheckRightSide();
        CheckLeftSide();
    }

    private void CheckRightSide()
    {
        if (PositionConvertor.IsOutsideView(spawnedTiles[^1].EntryPoint.position))
            return;
        
        AddTileToRight();
        nextRightTile = FindNextRightTile();
        CheckRightSide();

    }

    private void CheckLeftSide()
    {
        if (PositionConvertor.IsOutsideView(spawnedTiles[0].ExitPoint.position))
            return;
        
        AddTileToLeft();
        nextLeftTile = FindNextLeftTile();
        CheckLeftSide();
    }

    private void AddTileToRight()
    {
        Vector2 startPosition = new Vector2(spawnedTiles[^1].ExitPoint.position.x - nextRightTile.EntryPoint.localPosition.x, nextRightTile.EntryPoint.position.y);
        LevelTile levelTile = Instantiate(nextRightTile, startPosition, transform.rotation).GetComponent<LevelTile>();
        spawnedTiles.Add(levelTile);
        levelTile.onDestroyAction += () =>
        {
            OnTileDestroy(levelTile);
        };
    }

    private void AddTileToLeft()
    {
        Vector2 startPosition = new Vector2(spawnedTiles[0].EntryPoint.position.x - nextLeftTile.ExitPoint.localPosition.x, nextLeftTile.EntryPoint.position.y);
        LevelTile levelTile = Instantiate(nextLeftTile, startPosition, transform.rotation).GetComponent<LevelTile>();
        spawnedTiles.Insert(0, levelTile);
        levelTile.onDestroyAction += () =>
        {
            OnTileDestroy(levelTile);
        };
    }

    private void OnTileDestroy(LevelTile levelTile)
    {
        LevelTile tile = levelTile;
        int index = spawnedTiles.FindIndex(item=> tile == item);
        
        if (index == 0)
            nextLeftTile = ChangeNextLeftTileOnDelete();
        else
            nextRightTile = ChangeNextRightTileOnDelete();
            
        spawnedTiles.Remove(tile);
    }
}
