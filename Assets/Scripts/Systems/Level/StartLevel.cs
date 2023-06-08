using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public void StartGame()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        SceneManagementSystem.LoadScene("GameLevel");
    }
}
