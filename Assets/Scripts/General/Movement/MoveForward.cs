using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
         transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
