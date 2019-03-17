using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    private bool BookActive;
    private bool Lamp;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        BookActive = Player.GetComponentInChildren<Diary_Pause_Menu>().DiaryStartActive;
        Lamp = Player.GetComponent<Animator>().GetBool("Has Lantern");

        if(BookActive == true && Lamp == true)
        {
            //lancer anim barriere
        }
    }
}
