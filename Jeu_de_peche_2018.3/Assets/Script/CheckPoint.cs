using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private ParticleSystem Sparkle;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Sparkle = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var currentFear = other.gameObject.GetComponent<Fear_Manager>().m_currentFearLevel;
            if(currentFear >= 50)
            {
                other.gameObject.GetComponent<Fear_Manager>().m_currentFearLevel = 50;
            }
            gm.lastCheckPointPos = transform.position;
            Sparkle.Play();
        }
    }
}
