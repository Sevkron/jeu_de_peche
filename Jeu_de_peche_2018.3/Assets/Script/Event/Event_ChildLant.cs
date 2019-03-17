using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ChildLant : MonoBehaviour
{
    private GameObject Player;
    private GameObject Lantern;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Lantern = Player.transform.Find("Lant").gameObject.transform.Find("HeroLantern").gameObject;
        Lantern.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Interact"))
        {
            gameObject.SetActive(false);
            Lantern.SetActive(true);
            Player.GetComponent<Animator>().SetBool("Has Lantern", true);
        }
    }
}
