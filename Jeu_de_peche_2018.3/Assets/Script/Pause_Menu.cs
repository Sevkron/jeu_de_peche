using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor.Rendering.PostProcessing;
using UnityEngine.UI;

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Options()
    {
        m_optionsPanel.SetActive(true);
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
    }

    public void InvertJoysticks()
    {
        invertedJoysticks = !invertedJoysticks;
        player.GetComponent<CharacterController>().m_invertJoysticks = invertedJoysticks;
        player.GetComponent<CharacterController>().m_invertJoysticksPlayerOption = !player.GetComponent<CharacterController>().m_invertJoysticksPlayerOption;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
