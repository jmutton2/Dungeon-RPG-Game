using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayButton()
    {
        SceneManager.LoadScene("Opening");
    }

    public void IntructionsButton()
    {
        SceneManager.LoadScene("Instructions");
    }
}
