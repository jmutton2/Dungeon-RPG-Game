using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Text changingText;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the players final score
        changingText.text = GlobalVarStore.Score.ToString();
    }

    public void Restart()
    {
        //Sets the scene to the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
