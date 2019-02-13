using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject Paragraphe_Image;
    public GameObject Paragraphe_two;
    public GameObject Book;
    private GameObject DiaryButton;
    public bool Two_Note;
    public int NumberOfPage;
    

    void Start()
    {
        DiaryButton = GameObject.FindGameObjectWithTag("Diary");
    }

    private void OnTriggerStay(Collider other)
    {
        if( other.tag=="Player" && Input.GetButton("Interact"))
        {
            if (Two_Note == true)
            {
                Paragraphe_two.SetActive(true);
            }
            Paragraphe_Image.SetActive(true);
            Book.SetActive(true);
            Book.GetComponent<BookV2>().Page[Book.GetComponent<BookV2>().Current_Page].SetActive(false);
            Book.GetComponent<BookV2>().Current_Page = NumberOfPage;
            Book.GetComponent<BookV2>().Page[Book.GetComponent<BookV2>().Current_Page].SetActive(true);
            DiaryButton.GetComponent<Diary_Pause_Menu>().ButtonDiary.SetActive(true);
            DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryCanvasActive = true;
            gameObject.SetActive(false);
        }
    }

}
