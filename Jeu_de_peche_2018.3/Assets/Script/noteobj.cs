using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteobj : MonoBehaviour
{
    private GameObject Book;
    private GameObject DiaryButton;
    public int m_numberinArray;

    private void Start()
    {
        Book = GameObject.FindGameObjectWithTag("CanvasBook");
        DiaryButton = GameObject.FindGameObjectWithTag("Diary");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Interact"))
        {

            Book.GetComponent<Journal_test_Leo>().t_notes[m_numberinArray].SetActive(true);
            Book.GetComponent<Journal_test_Leo>().t_notes[m_numberinArray].transform.parent = Book.GetComponent<Journal_test_Leo>().children[Book.GetComponent<Journal_test_Leo>().index].transform;
            Book.GetComponent<Journal_test_Leo>().index++;
            Book.GetComponent<Journal_test_Leo>().t_notes[m_numberinArray].transform.localPosition = new Vector3(100, 0, 0);

            DiaryButton.GetComponent<Diary_Pause_Menu>().ButtonDiary.SetActive(true);
            DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryCanvasActive = true;
            gameObject.SetActive(false);
        }
    } 
}

