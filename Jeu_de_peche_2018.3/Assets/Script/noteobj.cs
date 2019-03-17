﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteobj : MonoBehaviour
{
    private GameObject Book;
    private GameObject DiaryButton;
    private GameObject Player;
    public int m_numberinArray;
    public GameObject m_Diary;
    private bool NotePrise;
    private bool BookActive = false;

    private void Start()
    {
        Book = GameObject.FindGameObjectWithTag("CanvasBook");
        DiaryButton = GameObject.FindGameObjectWithTag("Diary");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        NotePrise = true;
        BookActive = DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryStartActive;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Interact") && NotePrise == true)
        {
            if(BookActive == false)
            {
                DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryStartActive = true;
            }
            NotePrise = false;
            StartCoroutine(WaitAnimEnd());
        }
    } 
    IEnumerator WaitAnimEnd()
    {
        Player.GetComponent<Animator>().SetTrigger("Pickup");
        Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSecondsRealtime(2.7f);
        m_Diary.SetActive(true);
        
        Book.GetComponent<Journal_test_Leo>().t_notes[m_numberinArray].SetActive(true);
        Book.GetComponent<Journal_test_Leo>().t_notes[m_numberinArray].transform.parent = Book.GetComponent<Journal_test_Leo>().children[Book.GetComponent<Journal_test_Leo>().index].transform;
        Book.GetComponent<Journal_test_Leo>().index++;
        Book.GetComponent<Journal_test_Leo>().t_notes[m_numberinArray].transform.localPosition = new Vector3(100, 0, 0);

        DiaryButton.GetComponent<Diary_Pause_Menu>().ButtonDiary.SetActive(true);
        DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryCanvasActive = true;
        gameObject.SetActive(false);
    }
}

