using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Texture2D m_cursorTexture;
    public CursorMode m_cursorMode = CursorMode.Auto;
    public Vector2 m_hotSpot = Vector2.zero;

    public void PlayButton()
    {
        StartCoroutine(LoadMainMenu());
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadMainMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main_Scene");
        Cursor.SetCursor(m_cursorTexture, m_hotSpot, m_cursorMode);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}