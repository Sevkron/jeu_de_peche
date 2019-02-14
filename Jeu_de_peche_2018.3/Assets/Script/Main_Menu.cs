using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void Gallery()
    {
        SceneManager.LoadScene("Gallery_Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
