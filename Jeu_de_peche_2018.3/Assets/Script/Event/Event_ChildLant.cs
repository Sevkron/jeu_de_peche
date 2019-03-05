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
            Lantern = Player.transform.Find("Lantern").gameObject;
            Lantern.SetActive(true);
            Player.GetComponent<IKControl>().enabled = true;
        }
    }
}
