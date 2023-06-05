using UnityEngine;

public class PositionConvertor : MonoBehaviour
{
    private static Camera mainCamera = Camera.main;

    public static Vector2 ScreenToWorldVector2(Vector2 screenPosition)
    {
        return mainCamera.ScreenToWorldPoint(screenPosition);
    }
    
    public static Vector2 ViewportToWorldVector2(Vector2 viewportPosition)
    {
        return mainCamera.ViewportToWorldPoint(viewportPosition);
    }
    
    public static Vector2 ScreenToToViewport(Vector2 screenPosition)
    {
        return mainCamera.ScreenToViewportPoint(screenPosition);
    }
}
