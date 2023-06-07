using UnityEngine;
using System.Collections;

public class Enemy_AimShooter : Enemy, IShooter
{
    public float CoolDown => coolDown;
    public GameObject Bullet => bullet;
    
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject bullet;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GameObject target;

    private void OnEnable()
    {
        base.OnEnable();
        
        target = GameObject.FindGameObjectWithTag("Player");
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
        {
            Vector2 direction = target.transform.position - transform.position;
            Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.right, direction));
        }
        
        StartCoroutine(WaitAndShootIfOnScreen());
    }
}
