using System.Collections;
using UnityEngine;

public class DeleteOnDistanceFromCamera : MonoBehaviour
{
    [SerializeField] private float distance;

    private Camera mainCamera;
    
    private void OnEnable()
    {
        mainCamera = Camera.main;
        StartCoroutine(WaitForDistance());
    }

    private IEnumerator WaitForDistance()
    {
        yield return new WaitUntil(() => (mainCamera.transform.position - transform.position).sqrMagnitude > distance);
        Destroy(gameObject);
    }
}
