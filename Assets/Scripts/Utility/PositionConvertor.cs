using UnityEngine;

public class PositionConvertor : MonoBehaviour
{
    public static Vector2 ScreenToWorldVector2(Vector2 screenPosition)
    {
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
    
    public static Vector2 ViewportToWorldVector2(Vector2 viewportPosition)
    {
        return Camera.main.ViewportToWorldPoint(viewportPosition);
    }
    
    public static Vector2 ScreenToToViewport(Vector2 screenPosition)
    {
        return Camera.main.ScreenToViewportPoint(screenPosition);
    }
    
    public static Vector2 WorldVector2ToViewport(Vector2 worldPosition)
    {
        return Camera.main.WorldToViewportPoint(worldPosition);
    }

    public static bool IsOutsideView(Vector2 worldPosition)
    {
        Vector2 viewPosition = WorldVector2ToViewport(worldPosition);

        if (viewPosition.x > 1 || viewPosition.y > 1 || viewPosition.x < 0 || viewPosition.y < 0)
            return true;

        return false;
    }
}
