using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask affectingLayers;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private int damage;

    private void OnEnable()
    {
        PlayShootSound();
    }

    private void PlayShootSound()
    {
        sfx.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((affectingLayers & (1 << other.gameObject.layer)) == 0)
            return;
        
        other.gameObject.GetComponent<IHealthContainer>().ChangeHealth(-damage);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
