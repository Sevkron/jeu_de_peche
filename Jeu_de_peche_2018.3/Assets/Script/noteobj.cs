using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class noteobj : MonoBehaviour
{
    private GameObject Book;
    private GameObject DiaryButton;
    private GameObject Player;
    public int m_numberinArray;
    public GameObject m_Diary;
    private bool BookActive = false;
    private bool MeshRend;
    private EventSystem eventSystem;
    private GameObject GMA;


    private void Start()
    {
        Book = GameObject.FindGameObjectWithTag("CanvasBook");
        DiaryButton = GameObject.FindGameObjectWithTag("Diary");
        Player = GameObject.FindGameObjectWithTag("Player");
        eventSystem = EventSystem.current;
        GMA = GameObject.FindGameObjectWithTag("GM");
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRend = gameObject.GetComponent<Renderer>().enabled;
        BookActive = DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryStartActive;
        
        if (other.tag == "Player" && MeshRend == true)
        {
            GMA.GetComponent<GameMaster>().AfficherEA();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("Interact") && MeshRend == true)
        {
            if(BookActive == false)
            {
                DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryStartActive = true;
            }
            MeshRend = false;
            StartCoroutine(WaitAnimEnd());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GMA.GetComponent<GameMaster>().EnleverEA();
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
        eventSystem.SetSelectedGameObject(DiaryButton.GetComponent<Diary_Pause_Menu>().m_NextButton, new BaseEventData(eventSystem));


        DiaryButton.GetComponent<Diary_Pause_Menu>().ButtonDiary.SetActive(true);
        DiaryButton.GetComponent<Diary_Pause_Menu>().DiaryCanvasActive = true;

        GMA.GetComponent<GameMaster>().EnleverEA();
        gameObject.SetActive(false);
    }
}

