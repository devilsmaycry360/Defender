using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask affectingLayers;
    [SerializeField] private GameObject collisionEffect;

    public static Action OnPlayerCollision;

    private Action collisionEffectAction => PlayCollisionEffect;

    private void OnEnable()
    {
        OnPlayerCollision += collisionEffectAction;
    }

    private void OnDisable()
    {
        OnPlayerCollision -= collisionEffectAction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((affectingLayers & (1 << other.gameObject.layer)) == 0)
            return;
        
        OnPlayerCollision?.Invoke();
    }

    private void PlayCollisionEffect()
    {
        Instantiate(collisionEffect, transform.position, transform.rotation);
    }
}
