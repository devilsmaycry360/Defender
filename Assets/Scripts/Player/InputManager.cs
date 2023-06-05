using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 PointerWorldPosition
    {
        private set;
        get;
    }
    
    public static Vector2 PointerViewportPosition
    {
        private set;
        get;
    }
    
    public static bool IsHoldingFire
    {
        private set;
        get;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 pointerScreenPosition = context.ReadValue<Vector2>();
        PointerWorldPosition = PositionConvertor.ScreenToWorldVector2(pointerScreenPosition);
        PointerViewportPosition = PositionConvertor.ScreenToToViewport(pointerScreenPosition);
    }
    
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
            IsHoldingFire = true;
        else if (context.canceled)
            IsHoldingFire = false;
    }
}
