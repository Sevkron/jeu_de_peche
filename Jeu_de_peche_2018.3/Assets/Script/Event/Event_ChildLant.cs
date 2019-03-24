using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ChildLant : MonoBehaviour
{
    private GameObject Player;
    private GameObject Lantern;
    private bool LanternGround;
    private GameObject GMA;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Lantern = Player.transform.Find("Lant").gameObject.transform.Find("HeroLantern").gameObject;
        Lantern.SetActive(false);
        GMA = GameObject.FindGameObjectWithTag("GM");
    }

    private void OnTriggerEnter(Collider other)
    {
        LanternGround = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && LanternGround == true)
        {
            GMA.GetComponent<GameMaster>().AfficherEA();
            if (Input.GetButton("Interact"))
            {
                LanternGround = false;
                StartCoroutine(WaitAnimEnd());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GMA.GetComponent<GameMaster>().EnleverEA();
        }
    }

    IEnumerator WaitAnimEnd()
    {
        Player.GetComponent<Animator>().SetTrigger("Pickup");
        Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSecondsRealtime(2.7f);
        Player.GetComponent<CharacterController>().enabled = true;
        gameObject.SetActive(false);
        GMA.GetComponent<GameMaster>().EnleverEA();
        Lantern.SetActive(true);
        Player.GetComponent<Animator>().SetBool("Has Lantern", true);
    }
}
