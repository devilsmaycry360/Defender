using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float coolDown;

    private float coolDownTimer;
    private bool canShoot;
    
    private void Update()
    {
        CheckCoolDown();
        CheckShooting();
    }

    private void CheckCoolDown()
    {
        if (canShoot)
            return;

        coolDownTimer += Time.deltaTime;

        if (coolDownTimer >= coolDown)
            canShoot = true;
    }

    private void CheckShooting()
    {
        if (!InputManager.IsHoldingFire || !canShoot)
            return;

        Instantiate(bullet, transform.position, transform.rotation);
        ResetCoolDown();
    }

    private void ResetCoolDown()
    {
        coolDownTimer = 0.0f;
        canShoot = false;
    }
}
