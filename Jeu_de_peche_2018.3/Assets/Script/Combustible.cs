using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Combustible : MonoBehaviour
{
    private bool MeshRend;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRend = gameObject.GetComponent<MeshRenderer>().enabled;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && MeshRend == true)
        {
            if (Input.GetButton("Interact"))
            {
                MeshRend = false;
                StartCoroutine(WaitAnimEnd());
            }
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
    }
}
