using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 PointerWorldPosition
    {
        private set;
        get;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 pointerScreenPosition = context.ReadValue<Vector2>();
        PointerWorldPosition = ScreenPositionConvertor.ScreenToWorldVector2(pointerScreenPosition);
    }
}
