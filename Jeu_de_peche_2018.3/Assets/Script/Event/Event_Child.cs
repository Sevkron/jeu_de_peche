using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Child : MonoBehaviour
{
    public GameObject m_Child;
    public bool m_Event_With_Combustible;
    public bool m_Event_LightOff;

    private GameObject Lantern;

    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && m_Event_With_Combustible == false && m_Event_LightOff == false)
        {
            m_Child.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButton("Interact") && m_Event_With_Combustible == true)
            {
                m_Child.SetActive(true);
                gameObject.SetActive(false);
                Player.GetComponent<CharacterController>().enabled = false;
            }
            else if (Input.GetButton("Interact"))
            {
                gameObject.SetActive(false);
                Lantern = Player.transform.Find("Lantern").gameObject;
                Lantern.GetComponent<LanternScript>().currentLanternLight = 0;
            }
        }
    }
}
