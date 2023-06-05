using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask AffectingLayers;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((AffectingLayers | (1 << other.gameObject.layer)) == 0)
            return;

        other.gameObject.GetComponent<IHealthContainer>().ChangeHealth(-damage);
        Destroy(gameObject);
    }
}
