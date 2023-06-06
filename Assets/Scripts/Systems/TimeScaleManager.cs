using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    public static void ChangeTimeScale(float newScale)
    {
        Time.timeScale = newScale;
    }
}
