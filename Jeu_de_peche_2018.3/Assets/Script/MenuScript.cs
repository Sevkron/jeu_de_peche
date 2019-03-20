using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void PlayButton(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }

   
}