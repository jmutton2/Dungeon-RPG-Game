using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
