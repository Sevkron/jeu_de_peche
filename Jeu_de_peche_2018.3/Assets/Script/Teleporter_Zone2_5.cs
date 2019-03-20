using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter_Zone2_5 : MonoBehaviour
{
    private Transform teleportPoint;
    // Start is called before the first frame update
    void Start()
    {
        teleportPoint = gameObject.transform.Find("TeleportPos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = teleportPoint.position;
        }
    }
}
