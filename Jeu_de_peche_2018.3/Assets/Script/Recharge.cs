using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharge : MonoBehaviour
{
    private GameObject Player;
    private ParticleSystem Sparkle;
    private bool isActive = false;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Sparkle = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Player is in");
        if (other.tag == "Player")
        {

            if (Input.GetButton("Interact") && isActive == false)
            {
                isActive = true;
                StartCoroutine(WaitAnimEnd());
            }
        }
    }
    IEnumerator WaitAnimEnd()
    {
        Player.GetComponent<Animator>().SetTrigger("Pickup");
        Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSecondsRealtime(2.7f);
        Sparkle.Play();
        isActive = false;
        Player.GetComponent<CharacterController>().RechargeLamp();
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
