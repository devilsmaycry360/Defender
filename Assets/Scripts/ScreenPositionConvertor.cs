using UnityEngine;

public class ScreenPositionConvertor : MonoBehaviour
{
    private static Camera mainCamera = Camera.main;

    public static Vector2 ScreenToWorldVector2(Vector2 screenPosition)
    {
        return mainCamera.ScreenToWorldPoint(screenPosition);
    }
}
