using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField][Range(0,1)] private float minVerticalView = 0.2f;
    [SerializeField][Range(0,1)] private float maxVerticalView = 0.8f;

    private void Update()
    {
        MovePlayerVertically();
        KeepPlayerInVerticalViewLimits();
    }

    private void MovePlayerVertically()
    {
        Vector2 movingDirection = new Vector2(0, InputManager.PointerWorldPosition.y - transform.position.y);
        transform.Translate(movingDirection * Time.deltaTime * verticalSpeed);
    }

    private void KeepPlayerInVerticalViewLimits()
    {
        float minVerticalLimit = PositionConvertor.ViewportToWorldVector2(new Vector2(0, minVerticalView)).y;
        float maxVerticalLimit = PositionConvertor.ViewportToWorldVector2(new Vector2(0, maxVerticalView)).y;
        
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, minVerticalLimit, maxVerticalLimit));
    }
}
