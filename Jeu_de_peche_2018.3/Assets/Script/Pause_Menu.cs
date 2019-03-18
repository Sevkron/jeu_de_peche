using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause_Menu : MonoBehaviour
{
    public GameObject m_optionsPanel;

    public AudioMixer m_settingsAudioMixer;

    public Light m_mainLight;
    //private CharacterController PlayerScript;
    private GameObject player;
    private bool invertedJoysticks = false;

    private float sliderVolume = 1f;

    private float sliderBrightness = 0.5f;

    private EventSystem eventSystem;

    public GameObject m_PauseButton;
    public GameObject m_OptionButton;

    private GameObject Diaryscript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Diaryscript = GameObject.FindGameObjectWithTag("Diary");
        eventSystem = EventSystem.current;
    }

    public void Options()
    {
        Diaryscript.GetComponent<Diary_Pause_Menu>().MenuPause.SetActive(false);
        m_optionsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(m_OptionButton, new BaseEventData(eventSystem));
    }

    public void MasterVolume(float vol)
    {
        sliderVolume = vol;
    }

    public void Brightness(float light)
    {
        sliderBrightness = light;
    }

    public void AcceptOptions()
    {
        m_settingsAudioMixer.SetFloat("Master", sliderVolume);
        m_mainLight.intensity = sliderBrightness;
    }

    public void BackToPause()
    {
        m_optionsPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(m_PauseButton, new BaseEventData(eventSystem));
        Diaryscript.GetComponent<Diary_Pause_Menu>().MenuPause.SetActive(true);
    }

    public void InvertJoysticks()
    {
        invertedJoysticks = !invertedJoysticks;
        player.GetComponent<CharacterController>().m_invertJoysticks = invertedJoysticks;
        player.GetComponent<CharacterController>().m_invertJoysticksPlayerOption = !player.GetComponent<CharacterController>().m_invertJoysticksPlayerOption;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Diaryscript.GetComponent<Diary_Pause_Menu>().PauseCanvasActive = false;
        Diaryscript.GetComponent<Diary_Pause_Menu>().MenuPause.SetActive(false);
    }

    public void StartGame()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
