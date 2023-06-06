using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementSystem : MonoBehaviour
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
