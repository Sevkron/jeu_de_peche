using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algae : MonoBehaviour
{
    private GameObject Player;
    private float LantLight;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        LantLight = Player.GetComponentInChildren<LanternScript>().currentLanternLight;

        if (other.tag == "Player")
        {
            if (Input.GetButton("Interact") && LantLight > 20)
            {
                //play anim algue qui brule (coroutine)
                gameObject.SetActive(false);
                LantLight = LantLight - 20;
                Player.GetComponentInChildren<LanternScript>().currentLanternLight = LantLight;
            }
        }
    }
}
