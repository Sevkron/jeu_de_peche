using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOn : MonoBehaviour
{
    private float LantLight;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");  
    }

    private void OnTriggerStay(Collider other)
    {
        LantLight = Player.GetComponentInChildren<LanternScript>().currentLanternLight;
  
        if (other.tag == "Player" )
        {
            if (Input.GetButton("Interact") && LantLight > 0)
            {
                gameObject.GetComponent<Light>().enabled = true;
                gameObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
