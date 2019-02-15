using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Child2 : MonoBehaviour
{
    private GameMaster gm;
    private GameObject Player;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "End")
        {
            gameObject.SetActive(false);
        }
        if (other.tag == "Player")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.transform.position = gm.lastCheckPointPos;
            gameObject.SetActive(false);
        }
    }
}
