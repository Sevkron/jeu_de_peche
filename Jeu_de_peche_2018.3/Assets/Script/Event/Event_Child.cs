using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Child : MonoBehaviour
{
    public GameObject Child;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Child.SetActive(true);
            gameObject.SetActive(false);
        } 
    }
}
