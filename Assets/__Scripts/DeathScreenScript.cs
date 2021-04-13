using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{

    public Text changingText;
    // Start is called before the first frame update
    void Start()
    {
        changingText.text = GlobalVarStore.Score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
