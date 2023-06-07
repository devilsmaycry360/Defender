using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletLevels bulletLevels;

    private float coolDownTimer;
    private bool canShoot;
    private int currentBulletLevel;

    private void OnEnable()
    {
        currentBulletLevel = 0;
    }

    private void Update()
    {
        if (PlayerHealth.PlayerIsDead)
            return;
        
        CheckCoolDown();
        CheckShooting();
    }

    public void LevelUpBullet()
    {
        // currentBulletLevel++;
        currentBulletLevel = Mathf.Clamp(++currentBulletLevel, 0, bulletLevels.Levels.Length - 1);
    }

    private void CheckCoolDown()
    {
        if (canShoot)
            return;

        coolDownTimer += Time.deltaTime;

        if (coolDownTimer >= bulletLevels.Levels[currentBulletLevel].FireRate)
            canShoot = true;
    }

    private void CheckShooting()
    {
        if (!InputManager.IsHoldingFire || !canShoot)
            return;

        Instantiate(bulletLevels.Levels[currentBulletLevel].BulletPrefab, transform.position, transform.rotation);
        ResetCoolDown();
    }

    private void ResetCoolDown()
    {
        coolDownTimer = 0.0f;
        canShoot = false;
    }
}
