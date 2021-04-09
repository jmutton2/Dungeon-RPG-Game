using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
