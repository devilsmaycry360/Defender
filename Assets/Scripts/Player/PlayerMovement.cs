using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 2.0f;
    [SerializeField] private float verticalSpeed = 2.0f;
    [SerializeField][Range(0,1)] private float minVerticalView = 0.2f;
    [SerializeField][Range(0,1)] private float maxVerticalView = 0.8f;

    private void Update()
    {
        MovePlayerVertically();
        MovePlayerHorizontally();
    }

    private void MovePlayerHorizontally()
    {
        float pointerOffsetFromCenter = InputManager.PointerViewportPosition.x - 0.5f;
        float speedBasedOnOffset = pointerOffsetFromCenter * horizontalSpeed;
        transform.Translate(transform.right * Time.deltaTime * speedBasedOnOffset);
    }
    
    private void MovePlayerVertically()
    {
        Vector2 movingDirection = new Vector2(0, InputManager.PointerWorldPosition.y - transform.position.y);
        transform.Translate(movingDirection * Time.deltaTime * verticalSpeed);
        
        KeepPlayerInVerticalViewLimits();
    }

    private void KeepPlayerInVerticalViewLimits()
    {
        float minVerticalLimit = PositionConvertor.ViewportToWorldVector2(new Vector2(0, minVerticalView)).y;
        float maxVerticalLimit = PositionConvertor.ViewportToWorldVector2(new Vector2(0, maxVerticalView)).y;
        
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, minVerticalLimit, maxVerticalLimit));
    }
}
