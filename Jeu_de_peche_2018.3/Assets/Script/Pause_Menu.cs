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

    private float sliderVolume = 1f;

    public void Options()
    {
        m_optionsPanel.SetActive(true);
    }

    public void MasterVolume(float vol)
    {
        sliderVolume = vol;
    }

    public void AcceptOptions()
    {
        m_settingsAudioMixer.SetFloat("Master", sliderVolume);
    }

    public void BackToPause()
    {
        m_optionsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
