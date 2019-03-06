using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShadow : MonoBehaviour
{

    public GameObject Allume;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Allume.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Allume.SetActive(true);

        } 
    }
}
