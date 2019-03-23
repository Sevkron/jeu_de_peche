using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combustible : MonoBehaviour
{
    private bool MeshRend;
    private GameObject Player;
    private GameObject GMA;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GMA = GameObject.FindGameObjectWithTag("GM");
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRend = gameObject.GetComponent<MeshRenderer>().enabled;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && MeshRend == true)
        {
            GMA.GetComponent<GameMaster>().AfficherEA();

            if (Input.GetButton("Interact"))
            {
                MeshRend = false;
                StartCoroutine(WaitAnimEnd());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
           GMA.GetComponent<GameMaster>().EnleverEA();
        }
    }

    IEnumerator WaitAnimEnd()
    {
        Player.GetComponent<Animator>().SetTrigger("Pickup");
        Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSecondsRealtime(2.7f);
        gameObject.SetActive(false);
        Player.transform.GetComponent<CharacterController>().combustibleNum++;
        Player.transform.GetComponent<CharacterController>().UpdateCombustibleNum();
        Player.GetComponent<CharacterController>().enabled = true;
        GMA.GetComponent<GameMaster>().EnleverEA();
    }
}
