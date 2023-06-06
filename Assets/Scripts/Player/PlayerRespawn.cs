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
        playerHealth.OnHealthChanged += respawnAction;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= respawnAction;
    }

    private void RespawnPlayer()
    {
        StartCoroutine(PlayRespawnEffect());
        StartCoroutine(HandleBoxCollider());
        // StartCoroutine(HandleRespawPosition());
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

    private IEnumerator HandleRespawPosition()
    {
        yield return new WaitForSeconds(0.5f);
        
        Vector3 currentPosition = playerBoxCollider.transform.position;
        Vector2 newPosition = PositionConvertor.ViewportToWorldVector2(new Vector2(0.2f, 0.5f));
        playerBoxCollider.transform.position = new Vector3(newPosition.x, newPosition.y, currentPosition.z);
    }
}
