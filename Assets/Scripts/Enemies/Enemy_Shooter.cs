using UnityEngine;
using System.Collections;

public class Enemy_Shooter : Enemy, IShooter
{
    public float CoolDown => coolDown;
    public GameObject Bullet => bullet;
    
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject bullet;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        base.OnEnable();
        
        StartCoroutine(WaitAndShootIfOnScreen());
    }

    private void OnDisable()
    {
        base.OnDisable();
        
        StopCoroutine(WaitAndShootIfOnScreen());
    }

    private IEnumerator WaitAndShootIfOnScreen()
    {
        yield return new WaitForSeconds(coolDown);
        
        if (spriteRenderer.isVisible)
            Instantiate(bullet, transform.position, transform.rotation);
        
        StartCoroutine(WaitAndShootIfOnScreen());
    }
}
