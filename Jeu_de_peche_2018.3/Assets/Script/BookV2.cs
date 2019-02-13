using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookV2 : MonoBehaviour
{
    public GameObject[] Page;
    public int Current_Page;

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    void Start()
    {
        Page = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Page[i] = transform.GetChild(i).gameObject;
        }
        Current_Page = 0;
        gameObject.SetActive(false);
    }

    public void FLipPageToRight()
    {
        if(Current_Page < Page.Length-1)
        {
            Page[Current_Page].SetActive(false);
            Current_Page = Current_Page + 1;
            Page[Current_Page].SetActive(true);
        }
    }
    public void FLipPageToLeft()
    {
        if (Current_Page > 0)
        {
            Page[Current_Page].SetActive(false);
            Current_Page = Current_Page - 1;
            Page[Current_Page].SetActive(true);
        }
    }

}
