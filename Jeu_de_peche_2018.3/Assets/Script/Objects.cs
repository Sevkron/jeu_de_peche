using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private float startTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Object")
        {
            startTime = Time.time; //si on veux que le temps sois le meme pour chaque object changer le time.time

            if (startTime >= 4.0)
            {
                ResetTimer();
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
            if (other.tag == "Object")
            {
                ResetTimer();
            }
    }
    
    private void ResetTimer()
        {
            startTime = 0.0f;
        }
}
