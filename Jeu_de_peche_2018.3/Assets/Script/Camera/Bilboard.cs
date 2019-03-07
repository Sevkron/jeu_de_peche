using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private GameObject MainCam;

    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + MainCam.transform.rotation * Vector3.forward,
           MainCam.transform.rotation * Vector3.up);
    }
}
