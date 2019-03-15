using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Combustible : MonoBehaviour
{
    private bool MeshRend;
    private ParticleSystem Pick_up;

    private void OnTriggerStay(Collider other)
    {
        MeshRend = gameObject.GetComponent<MeshRenderer>().enabled;

        if (other.tag == "Player" && MeshRend == true)
        {
            var player = other.gameObject;
            //var ch = player.transform.GetComponent<CharacterController>().combustibleNum;
            if (Input.GetButton("Interact"))
            {
                StartCoroutine(waitparticle());
                //gameObject.SetActive(false);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<SphereCollider>().enabled = false;
                player.transform.GetComponent<CharacterController>().combustibleNum++;
                player.transform.GetComponent<CharacterController>().UpdateCombustibleNum();
            }
        }
    }

    IEnumerator waitparticle()
    {
        Pick_up = gameObject.GetComponentInChildren<ParticleSystem>();
        Pick_up.Play();
        yield return new WaitForSecondsRealtime(3);
    }
}
