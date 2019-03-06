using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cry : MonoBehaviour
{
    public Animator PleureLa;
    // Start is called before the first frame update
    void Start()
    {
        PleureLa = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Takepicture.victoryL)
        {
            PleureLa.Play("animgoute");
        }
    }
}
