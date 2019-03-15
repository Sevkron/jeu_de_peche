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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Interact"))
        {
            gameObject.SetActive(false);
            //Lantern = Player.transform.Find("Lantern").gameObject;
            Lantern = Player.transform.Find("Heroine_rigg").gameObject.transform.Find("R_hand_jnt").gameObject.transform.Find("HeroLantern").gameObject;
            Lantern.SetActive(true);
            Player.GetComponent<Animator>().SetBool("Has Lantern", true);
            //Player.GetComponent<IKControl>().enabled = true;
        }
    }
}
