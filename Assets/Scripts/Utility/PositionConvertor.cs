using Unity.VisualScripting;
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
    
    public static Vector2 WorldVector2ToViewport(Vector2 worldPosition)
    {
        return mainCamera.WorldToViewportPoint(worldPosition);
    }

    public static bool IsOutsideView(Vector2 worldPosition)
    {
        Vector2 viewPosition = WorldVector2ToViewport(worldPosition);

        if (viewPosition.x > 1 || viewPosition.y > 1 || viewPosition.x < 0 || viewPosition.y < 0)
            return true;

        return false;
    }
}
