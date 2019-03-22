using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    private GameObject Player;
    public AudioClip deathSFX;
    private Animator playerAnim;
    public GameObject m_DeathScreen;

    private bool isScaryAmbience;
    public AudioSource m_AmbienceAudioSource;
    public AudioClip m_NormalAmbience;
    public AudioClip m_ScaryAmbience;

    private void Awake()
    {
        if( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        m_AmbienceAudioSource.clip = m_NormalAmbience;
        isScaryAmbience = false;
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = Player.GetComponent<Animator>();
    }

    public void Death()
    {
        playerAnim.SetTrigger("Dead");
        Player.GetComponent<CharacterController>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(deathSFX);
        Player.GetComponent<Fear_Manager>().m_currentFearLevel = 0;
        m_DeathScreen.GetComponent<Animator>().SetTrigger("DeathScreenActivate");
        //particule de smoke 
    }

    public void Respawn()
    {
        Player.transform.position = lastCheckPointPos;
        playerAnim.SetTrigger("Respawn");
        Player.GetComponent<CharacterController>().enabled = true;
        m_DeathScreen.GetComponent<Animator>().SetTrigger("DeathScreenDeactivate");
    }

    public void ChangeAmbience()
    {
        if (isScaryAmbience == true)
        {
            m_AmbienceAudioSource.clip = m_ScaryAmbience;
            m_AmbienceAudioSource.Play();
        }
        else
        {
            m_AmbienceAudioSource.clip = m_NormalAmbience;
            m_AmbienceAudioSource.Play();
        }
    }
}
