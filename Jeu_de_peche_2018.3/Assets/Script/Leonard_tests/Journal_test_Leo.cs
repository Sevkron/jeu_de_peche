using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal_test_Leo : MonoBehaviour
{
    //public GameObject note1, note2, note3; //notes
    //public GameObject p12, p34, p56, p78, p910;

    public GameObject journal;

    //tableau des emplacements libres
    public GameObject[] children;
    public int index = 0;

    //tableau des notes
    public GameObject notes;
    public GameObject[] t_notes;

    //tableau des pages
    public GameObject[] t_pages;
    public int p_index; //index page actuelle

    //index nb enfants dans cases du tableau

    void Start()
    {
        p_index = 0;
        //setup des tableaux (emplacements + notes + nb pages)
        children = new GameObject[30];
        t_notes = new GameObject[notes.transform.childCount];
        t_pages = new GameObject[journal.transform.childCount];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                children[index] = journal.transform.GetChild(i).GetChild(j).gameObject;
                index++;
            }
        }
        index = 0;

        for (int i = 0; i < t_notes.Length; i++)
        {
            t_notes[i] = notes.transform.GetChild(i).gameObject;
            notes.transform.GetChild(i).gameObject.SetActive(false); //on désactive toutes les notes
        }

        for (int i = 0; i < t_pages.Length; i++)
        {
            t_pages[i] = journal.transform.GetChild(i).gameObject;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            t_notes[0].SetActive(true);
            t_notes[0].transform.parent = children[index].transform;
            index++;
            t_notes[0].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("oui");
            t_notes[1].SetActive(true);
            t_notes[1].transform.parent = children[index].transform;
            index++;
            t_notes[1].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log("oui");
            t_notes[2].SetActive(true);
            t_notes[2].transform.parent = children[index].transform;
            index++;
            t_notes[2].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("oui");
            t_notes[3].SetActive(true);
            t_notes[3].transform.parent = children[index].transform;
            index++;
            t_notes[3].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Debug.Log("oui");
            t_notes[4].SetActive(true);
            t_notes[4].transform.parent = children[index].transform;
            index++;
            t_notes[4].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Debug.Log("oui");
            t_notes[5].SetActive(true);
            t_notes[5].transform.parent = children[index].transform;
            index++;
            t_notes[5].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Debug.Log("oui");
            t_notes[6].SetActive(true);
            t_notes[6].transform.parent = children[index].transform;
            index++;
            t_notes[6].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Debug.Log("oui");
            t_notes[7].SetActive(true);
            t_notes[7].transform.parent = children[index].transform;
            index++;
            t_notes[7].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Debug.Log("oui");
            t_notes[8].SetActive(true);
            t_notes[8].transform.parent = children[index].transform;
            index++;
            t_notes[8].transform.localPosition = new Vector3(100, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Debug.Log("oui");
            t_notes[9].SetActive(true);
            t_notes[9].transform.parent = children[index].transform;
            index++;
            t_notes[9].transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public void TurnLeft()
    {
            if (p_index > 0)
            {
                t_pages[p_index].SetActive(false);
                p_index--;
                t_pages[p_index].SetActive(true);
                Debug.Log("On tourne à gauche !");
            }
        }

    public void TurnRight()
        {
            if (p_index != 4)
            {
                t_pages[p_index].SetActive(false);
                p_index++;
                t_pages[p_index].SetActive(true);
                Debug.Log("On tourne à droite !");
            }
        }
}
