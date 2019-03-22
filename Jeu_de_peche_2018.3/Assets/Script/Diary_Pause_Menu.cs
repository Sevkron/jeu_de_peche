﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Diary_Pause_Menu : MonoBehaviour
{
    public GameObject m_CanvasDiary;
    public bool DiaryCanvasActive = false;
    public bool DiaryStartActive;

    public GameObject ButtonDiary;
    public GameObject m_NextButton;
    public GameObject m_PauseButton;
    public GameObject m_StartButton;

    public GameObject MenuPause;
    public bool PauseCanvasActive = false;
    public bool OptionCanvasActive = false;

    private EventSystem eventSystem;

    private bool HasStarted;



    void Start()
    {
        ButtonDiary = GameObject.FindGameObjectWithTag("Button");
        ButtonDiary.SetActive(false);
        MenuPause = GameObject.FindGameObjectWithTag("Pause");
        MenuPause.SetActive(false);
        eventSystem = EventSystem.current;
        DiaryStartActive = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Diary") && DiaryCanvasActive == false && PauseCanvasActive == false && DiaryStartActive == true && OptionCanvasActive == false)
        {
                eventSystem.SetSelectedGameObject(m_NextButton, new BaseEventData(eventSystem));
                m_CanvasDiary.SetActive(true);
                ButtonDiary.SetActive(true);
                DiaryCanvasActive = true;
                GetComponentInParent<CharacterController>().enabled = false;
            }

        else if(Input.GetButtonDown("Diary") && DiaryCanvasActive == true)
            {
                 m_CanvasDiary.SetActive(false);
                 ButtonDiary.SetActive(false);
                 GetComponentInParent<CharacterController>().enabled = true;
                 DiaryCanvasActive = false;
        }

        if(Input.GetButtonDown("Pause") && PauseCanvasActive == false && DiaryCanvasActive == false && OptionCanvasActive == false)
        {
            eventSystem.SetSelectedGameObject(m_PauseButton, new BaseEventData(eventSystem));
            Time.timeScale = 0;
            MenuPause.SetActive(true);
            PauseCanvasActive = true;
        }

        else if(Input.GetButtonDown("Pause") && PauseCanvasActive == true && OptionCanvasActive == false)
        {
            HasStarted = gameObject.GetComponentInParent<Animator>().GetBool("HasStart");
            if(HasStarted == false)
            {
                eventSystem.SetSelectedGameObject(m_StartButton, new BaseEventData(eventSystem));
            }
            Time.timeScale = 1;
            MenuPause.SetActive(false);
            PauseCanvasActive = false;
        }
    }
}
