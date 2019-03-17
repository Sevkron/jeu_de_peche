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
    }

    public void Death()
    {
        //Put effects from fear manager here
        playerAnim.SetTrigger("Dead");
        Player.GetComponent<CharacterController>().enabled = false;
        Player.GetComponent<Fear_Manager>().m_currentFearLevel = 0;
        GetComponent<AudioSource>().PlayOneShot(deathSFX);
        Player.transform.position = lastCheckPointPos;
        playerAnim.SetTrigger("Respawn");
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
