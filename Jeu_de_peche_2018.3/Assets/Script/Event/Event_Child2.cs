using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Child2 : MonoBehaviour
{
    private GameMaster gm;
    private GameObject Player;
    private GameObject Lantern;
    public GameObject m_Lantern_Au_Sol;
    public bool m_Event_With_Combustible;
    public Transform m_target;
    public float speed;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_target.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "End")
        {
            gameObject.SetActive(false);
        }
        else if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            Player.GetComponent<Animator>().SetBool("Has Lantern", false);
            gm.GetComponent<GameMaster>().Death();

            if(m_Event_With_Combustible== true)
            {
                Player.GetComponent<CharacterController>().enabled = true;
                //Lantern = Player.transform.Find("Lantern").gameObject;
                Lantern = Player.transform.Find("Lant").gameObject.transform.Find("HeroLantern").gameObject;
                Lantern.SetActive(false);
                //animantore bool a changer
                Player.GetComponent<Animator>().SetBool("Has Lantern", false);
                m_Lantern_Au_Sol.SetActive(true);
            }
        }
    }
}
