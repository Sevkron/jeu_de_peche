using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = true; 
            //si posibilite de marcher sur la planche sans qu'elle tombe selon vitesse rajouter varriable
        }
    }
}
