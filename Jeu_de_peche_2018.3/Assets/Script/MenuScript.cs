using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("Main_Scene");
    }

   
}