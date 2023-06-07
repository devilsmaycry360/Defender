using UnityEngine;
using System.Collections;

public class Enemy_AimShooter : Enemy, IShooter
{
    public float CoolDown => coolDown;
    public GameObject Bullet => bullet;
    
    [SerializeField] private float coolDown;
    [SerializeField] private GameObject bullet;

    private GameObject target;

    private void OnEnable()
    {
        base.OnEnable();
        
        target = GameObject.FindGameObjectWithTag("Player");
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
        Vector2 direction = target.transform.position - transform.position;
        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.right, direction));
        StartCoroutine(WaitAndShoot());
    }
}
