using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Player : MonoBehaviour
{

    private GameObject Child_Parent;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag== "Player" && Input.GetButton("Interact"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            if(gameObject.name == "Parent")
            {
                Child_Parent = transform.GetChild(0).gameObject;
                GameObject.FindGameObjectWithTag("Player").transform.position = Child_Parent.transform.position;
            }
            else if(gameObject.name == "Child")
            {
                Child_Parent = this.transform.parent.gameObject;
                GameObject.FindGameObjectWithTag("Player").transform.position = Child_Parent.transform.position;
            }
            StartCoroutine(Activate_collider()); 
        }
    }
    
    IEnumerator Activate_collider()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Child_Parent.GetComponent<BoxCollider>().isTrigger = true;
        yield return null;
    }
}
