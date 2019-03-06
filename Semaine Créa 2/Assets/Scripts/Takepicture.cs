using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takepicture : MonoBehaviour
{
    public Animator Prendlatof;
    public static bool victoryL;
    // Start is called before the first frame update
    void Start()
    {
        Prendlatof = GetComponent<Animator>();
        victoryL = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            victoryL = true;
            Debug.Log("bruhhrhhh");
            Prendlatof.Play("pleuretarace");
        }
    }
}
