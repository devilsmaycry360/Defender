using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUI : MonoBehaviour
{
    private void Start()
    {
        SceneManagementSystem.LoadScene("GameUI", LoadSceneMode.Additive);
    }

}
