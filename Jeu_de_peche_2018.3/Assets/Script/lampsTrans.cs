using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampsTrans : MonoBehaviour
{
    public GameObject Hand;

    void Update()
    {
        gameObject.transform.position = Hand.transform.position;
    }
}
