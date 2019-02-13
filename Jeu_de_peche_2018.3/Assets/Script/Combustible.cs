using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Combustible : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = other.gameObject;
            //var ch = player.transform.GetComponent<CharacterController>().combustibleNum;
            if (Input.GetButton("Interact"))
            {
                gameObject.SetActive(false);
                player.transform.GetComponent<CharacterController>().combustibleNum++;
                player.transform.GetComponent<CharacterController>().UpdateCombustibleNum();
            }
        }
    }
}
