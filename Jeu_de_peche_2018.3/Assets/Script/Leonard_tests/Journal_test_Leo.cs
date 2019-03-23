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

    public AudioClip SFXSelected;
    public AudioClip SFXValidated;
    public AudioClip SFXPage;
    private AudioSource UiAudioSource;


    void Start()
    {
        UiAudioSource = this.gameObject.GetComponent<AudioSource>();
        p_index = 0;
        //setup des tableaux (emplacements + notes + nb pages)
        children = new GameObject[30];
        t_notes = new GameObject[notes.transform.childCount];
        t_pages = new GameObject[journal.transform.childCount];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
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
    public void PlaySoundSelected()
    {
        UiAudioSource.PlayOneShot(SFXSelected);
    }

    public void PlaySoundValidated()
    {
        UiAudioSource.PlayOneShot(SFXValidated);
    }

    public void PlaySoundPage()
    {
        UiAudioSource.PlayOneShot(SFXPage);
    }

}
