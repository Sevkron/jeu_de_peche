using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOff : MonoBehaviour
{
    private GameObject[] OffLight;
    private GameObject Player;
    private float LvlLight;

    void Start()
    {
        OffLight = GameObject.FindGameObjectsWithTag("Light");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        LvlLight = Player.GetComponentInChildren<LanternScript>().currentLanternLight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && LvlLight < 20)
        {
           for(int i=0; i< OffLight.Length; i++)
            {
                OffLight[i].GetComponent<ParticleSystem>().Stop();
                OffLight[i].GetComponent<Light>().intensity=0;
            }
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
