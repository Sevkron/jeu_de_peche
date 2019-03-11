using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Audio;

public class Fear_Manager : MonoBehaviour
{
    public float m_currentFearLevel = 0;

    private float minFear = 0;
    private float maxFear = 100;

    public GameObject m_Lantern;
    private GameMaster gm;
    private PostProcessVolume pPVolume;
    Vignette vignette;
    private bool vignetteIsActive;

    public AudioMixer audioMixer;
    private AudioMixerSnapshot defaultSnapshot;
    private AudioMixerSnapshot fearSnapshot;

    private float fearModifier;
    private float currentLight;
    // Start is called before the first frame update
    void Start()
    {
        //m_currentFearLevel = 0;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        defaultSnapshot = audioMixer.FindSnapshot("Snapshot");
        fearSnapshot = audioMixer.FindSnapshot("Fear");
        //pPVolume = gm.gameObject.GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLight = m_Lantern.GetComponent<LanternScript>().currentLanternLight;
        m_currentFearLevel = m_currentFearLevel + fearModifier * Time.deltaTime;
        if (currentLight >= 25 && m_currentFearLevel > minFear)
        {
            fearModifier = -1f;
        }else if(currentLight < 25 && currentLight > 10)
        {
            fearModifier = 1f;
        }
        else if(currentLight <= 10)
        {
            fearModifier = 2f ;
        }
        else
        {
            fearModifier = 0;
        }

        if(m_currentFearLevel > 20)
        {
            vignetteIsActive = true;
            vignette = ScriptableObject.CreateInstance<Vignette>();
            vignette.enabled.Override(true);
            vignette.intensity.Override(0.40f);

            var volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);
            volume.weight = 0f;

            DOTween.Sequence()
                .Append(DOTween.To(() => volume.weight, x => volume.weight = x, 1f, 2000f));
        }
        else if (m_currentFearLevel > 50)
        {
            fearSnapshot.TransitionTo(1f);
        }
        else if (m_currentFearLevel > 75)
        {

        }
        else if(m_currentFearLevel >= maxFear)
        {
            defaultSnapshot.TransitionTo(.5f);
            //GetComponentInParent
            Debug.Log("You Dead");
            this.transform.position = gm.lastCheckPointPos;
            m_currentFearLevel = minFear;
        }
        else
        {
            if (vignetteIsActive == true)
            {
                vignette.enabled.Override(false);
                vignette.intensity.Override(0);
            }
            else
            {
                return;
            }
        }
    }
}
