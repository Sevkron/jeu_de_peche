using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary_Pause_Menu : MonoBehaviour
{
    public GameObject m_CanvasDiary;
    public bool DiaryCanvasActive = false;

    public GameObject ButtonDiary;

    private GameObject MenuPause;
    private bool PauseCanvasActive = false;

    void Start()
    {
        ButtonDiary = GameObject.FindGameObjectWithTag("Button");
        ButtonDiary.SetActive(false);
        MenuPause = GameObject.FindGameObjectWithTag("Pause");
        MenuPause.SetActive(false);
    }

    void Update()
    {
        

        if (Input.GetButton("Diary") && DiaryCanvasActive == false && PauseCanvasActive == false)
            {
                m_CanvasDiary.SetActive(true);
                ButtonDiary.SetActive(true);
                DiaryCanvasActive = true;


                GetComponentInParent<CharacterController>().enabled = false;
            }
        
            if (Input.GetButton("Cancel") && DiaryCanvasActive == true)
            {
                 m_CanvasDiary.SetActive(false);
                 ButtonDiary.SetActive(false);
                 GetComponentInParent<CharacterController>().enabled = true;
                 DiaryCanvasActive = false;
        }

        if (Input.GetButton("Pause") && PauseCanvasActive == false && DiaryCanvasActive == false)
        {
            Time.timeScale = 0;
            MenuPause.SetActive(true);
            PauseCanvasActive = true;
        }

        if (Input.GetButton("Cancel") && PauseCanvasActive == true)
        {
            Time.timeScale = 1;
            MenuPause.SetActive(false);
            PauseCanvasActive = false;
        }
    }
}
