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
    private AudioSource AudioSourceAmbience;
    private AudioMixerSnapshot defaultSnapshot;
    private AudioMixerSnapshot fearSnapshot;

    private IEnumerator coroutuneInvertControls;
    private bool coroutineActive;
    private bool invertJoysticksPlayerOption;

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
            fearModifier = -0.5f;
        }else if(currentLight < 25 && currentLight > 10)
        {
            fearModifier = 0.5f;
        }
        else if(currentLight <= 10)
        {
            fearModifier = 1f ;
        }
        else
        {
            fearModifier = 0;
        }

        if(m_currentFearLevel >= 20 && m_currentFearLevel < 50)
        {
            defaultSnapshot.TransitionTo(2f);

            vignetteIsActive = true;
            vignette = ScriptableObject.CreateInstance<Vignette>();
            vignette.enabled.Override(true);
            vignette.intensity.Override(0.40f);

            var volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);
            volume.weight = 0f;

            DOTween.Sequence()
                .Append(DOTween.To(() => volume.weight, x => volume.weight = x, 1f, 2000f));
        }
        else if (m_currentFearLevel >= 50 && m_currentFearLevel < 75)
        {
            //this.GetComponent<CharacterController>().m_invertJoysticks = this.GetComponent<CharacterController>().m_invertJoysticksPlayerOption;
            fearSnapshot.TransitionTo(2f);
            /*if (coroutineActive == true)
            {
                StopCoroutine("InvertControls");
            }*/
        }
        else if (m_currentFearLevel >= 75 && m_currentFearLevel < maxFear)
        {

            /*coroutuneInvertControls = InvertControls(5f);
            if (coroutineActive == false)
            {
                StartCoroutine(coroutuneInvertControls);
                coroutineActive = true;
            }*/
        }
        else if(m_currentFearLevel >= maxFear)
        {
            //StopCoroutine("InvertControls");
            defaultSnapshot.TransitionTo(2f);
            //GetComponentInParent
            Debug.Log("You Dead");
            //this.GetComponent<CharacterController>().m_invertJoysticks = this.GetComponent<CharacterController>().m_invertJoysticksPlayerOption;
            gm.GetComponent<GameMaster>().Death();
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

    IEnumerator InvertControls(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("Inverting controls");
        bool inverted = this.GetComponent<CharacterController>().m_invertJoysticks;
        this.GetComponent<CharacterController>().m_invertJoysticks = !inverted;
        yield return new WaitForSeconds(WaitTime);
        coroutineActive = false;
    }
}
