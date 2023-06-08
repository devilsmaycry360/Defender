using System;
using UnityEngine;

public class SetGameoverUI : MonoBehaviour
{
    [SerializeField] private GameObject  gameover;
    
    private PlayerHealth playerHealth;
    private Action ShowGameoverAction => ShowGameover;

    private void OnEnable()
    {
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();
        
        gameover.SetActive(false);
        playerHealth.OnDeath += ShowGameoverAction;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= ShowGameoverAction;
    }

    private void ShowGameover()
    {
        gameover.SetActive(true);
    }
}
