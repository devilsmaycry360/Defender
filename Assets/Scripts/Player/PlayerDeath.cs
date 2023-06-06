using System;
using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private PlayerMovement playerMovement;

    private Action deathAction;
    
    private void OnEnable()
    {
        deathAction = () => StartCoroutine(WaitAndRestart());
        playerHealth.OnDeath += deathAction;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= deathAction;
    }

    private IEnumerator WaitAndRestart()
    {
        DisablePlayer();
        yield return new WaitForSeconds(2);
        RestartGame();
    }

    private void DisablePlayer()
    {
        playerSpriteRenderer.enabled = false;
        playerMovement.enabled = false;
    }

    private void RestartGame()
    {
        SceneManagementSystem.LoadScene("Menu");
    }
}
