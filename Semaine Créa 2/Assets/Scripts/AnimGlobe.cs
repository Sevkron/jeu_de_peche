using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGlobe : MonoBehaviour
{
    public Animator GlobeTourne;

    // Start is called before the first frame update
    void Start()
    {
        GlobeTourne = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Sesameouvretoi");
            GlobeTourne.Play("animtoi");
        }
    }
}
