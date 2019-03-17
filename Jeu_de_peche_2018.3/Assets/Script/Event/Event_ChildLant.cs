using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ChildLant : MonoBehaviour
{
    private GameObject Player;
    private GameObject Lantern;
    private bool LanternGround;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Lantern = Player.transform.Find("Lant").gameObject.transform.Find("HeroLantern").gameObject;
        Lantern.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        LanternGround = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Interact") && LanternGround == true)
        {
            LanternGround = false;
            StartCoroutine(WaitAnimEnd());
        }
    }

    IEnumerator WaitAnimEnd()
    {
        Player.GetComponent<Animator>().SetTrigger("Pickup");
        Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSecondsRealtime(2.7f);
        Player.GetComponent<CharacterController>().enabled = true;
        gameObject.SetActive(false);
        Lantern.SetActive(true);
        Player.GetComponent<Animator>().SetBool("Has Lantern", true);
    }
}
