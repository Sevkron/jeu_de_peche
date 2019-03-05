using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_area : MonoBehaviour
{
    private GameMaster gm;
    private GameObject Player;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Planche")
        {
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Player")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.transform.position = gm.lastCheckPointPos;
        }
    }
}
