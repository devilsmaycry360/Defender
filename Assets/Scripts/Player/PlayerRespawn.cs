using System;
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private BoxCollider2D playerBoxCollider;

    private Action respawnAction => RespawnPlayer;

    private void OnEnable()
    {
        playerHealth.OnHealthDecrease += respawnAction;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthDecrease -= respawnAction;
    }

    private void RespawnPlayer()
    {
        StartCoroutine(PlayRespawnEffect());
        StartCoroutine(HandleBoxCollider());
    }
    
    private IEnumerator PlayRespawnEffect()
    {
        Color currentColor = playerSpriteRenderer.color;
        playerSpriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.2f);

        yield return new WaitForSeconds(3);

        playerSpriteRenderer.color = currentColor;
    }
    
    private IEnumerator HandleBoxCollider()
    {
        playerBoxCollider.enabled = false;

        yield return new WaitForSeconds(3);

        playerBoxCollider.enabled = true;
    }
}
