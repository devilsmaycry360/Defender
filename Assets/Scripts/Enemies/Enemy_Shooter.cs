using UnityEngine;
using System.Collections;

public class Enemy_Shooter : Enemy, IShooter
{
    public float CoolDown => coolDown;
    public GameObject Bullet => bullet;
    
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject bullet;

    private void OnEnable()
    {
        base.OnEnable();
        
        StartCoroutine(WaitAndShoot());
    }

    private void OnDisable()
    {
        base.OnDisable();
        
        StopCoroutine(WaitAndShoot());
    }

    private IEnumerator WaitAndShoot()
    {
        yield return new WaitForSeconds(coolDown);
        Instantiate(bullet, transform.position, transform.rotation);
        StartCoroutine(WaitAndShoot());
    }
}
