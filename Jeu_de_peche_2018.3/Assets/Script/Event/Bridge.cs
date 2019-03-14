using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private Rigidbody rigidbody;
    private GameObject Player;
    public GameObject WoodCrac;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //if (Player . variable de vitesse > 20)
            WoodCrac.SetActive(true);
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = true;

            //if (Player . variable de vitesse < 20)
            //lancer son planche qui craque
            //si posibilite de marcher sur la planche sans qu'elle tombe selon vitesse rajouter varriable
        }
    }
}
