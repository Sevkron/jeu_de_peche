﻿using System.Collections;
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
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = Player.GetComponent<Animator>();
        m_DeathScreen = GameObject.FindGameObjectWithTag("CanvasBook").gameObject.transform.Find("DeathScreen").gameObject;
    }

    public void Death()
    {
        playerAnim.SetTrigger("Dead");
        Player.GetComponent<CharacterController>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(deathSFX);
        Player.GetComponent<Fear_Manager>().m_currentFearLevel = 0;
        m_DeathScreen.SetActive(true);
        //particule de smoke 
    }

    public void Respawn()
    {
        m_DeathScreen.SetActive(false);
        Player.transform.position = lastCheckPointPos;
        playerAnim.SetTrigger("Respawn");
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
