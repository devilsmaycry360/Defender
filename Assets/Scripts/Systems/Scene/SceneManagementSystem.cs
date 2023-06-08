using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementSystem : MonoBehaviour
{
    public static void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(name, mode);
    }

    public static string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
