using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public int m_numberintheTab;
    //private Sprite SpriteBook;
    public Sprite m_Note;
    public Book m_scriptBook;
    public GameObject m_Player;
    private int DiaryCurrentPage;
    private int numberBookPageTurn;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetButton("Interact"))
        {
            m_scriptBook.bookPages[m_numberintheTab] = m_Note;
                
            if ( m_numberintheTab % 2 == 1)
             {
                m_numberintheTab = m_numberintheTab + 1;
             }
             //DiaryCurrentPage = m_Player.GetComponentInChildren<Diary>().ActualPage;
             m_Player.GetComponent<CharacterController>().enabled = false;
             m_scriptBook.transform.parent.gameObject.SetActive(true);

            if (DiaryCurrentPage < m_numberintheTab)
             {
                 numberBookPageTurn = DiaryCurrentPage*1/2-m_numberintheTab*1/2*-1;
                 StartCoroutine(InvokeMethod(TurnRight, 2.5f, numberBookPageTurn));  
             }
             else if(DiaryCurrentPage > m_numberintheTab)
             {
                 numberBookPageTurn = DiaryCurrentPage*1/2-m_numberintheTab*1/2;
                 StartCoroutine(InvokeMethod(TurnLeft, 2.5f, numberBookPageTurn));
             }
             else
             {
                 m_scriptBook.currentPage = DiaryCurrentPage - 2;
                 m_scriptBook.GetComponent<AutoFlip>().FlipRightPage();
                 gameObject.SetActive(false);
             }
        }
    }
    private IEnumerator InvokeMethod(Action Method, float interval, int invokeCount)
    {
        for (int i = 0; i < invokeCount; i++)
        {
            Method();
            yield return new WaitForSecondsRealtime(interval);
            yield return null;
        }
        gameObject.SetActive(false);
        yield return null;
    }

    private void TurnLeft()

     {
         m_scriptBook.GetComponent<AutoFlip>().FlipLeftPage();
     }

     private void TurnRight()
     {
        m_scriptBook.GetComponent<AutoFlip>().FlipRightPage();
     }

}
