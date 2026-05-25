using UnityEngine;
using UnityEngine.SceneManagement;

public class managerTitle : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
