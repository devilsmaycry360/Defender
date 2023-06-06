using UnityEngine;

public class DeleteOutOfScreen : MonoBehaviour
{
    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
