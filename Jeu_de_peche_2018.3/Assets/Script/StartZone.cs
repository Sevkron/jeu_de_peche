using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartZone : MonoBehaviour
{
    private bool BookActive;
    private bool Lamp;
    private GameObject Player;
    public PlayableDirector church;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        BookActive = Player.GetComponentInChildren<Diary_Pause_Menu>().DiaryStartActive;
        Player.GetComponent<Fear_Manager>().m_currentFearLevel = 0;
        Lamp = Player.GetComponent<Animator>().GetBool("Has Lantern");

        if(BookActive == true && Lamp == true)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            church.Play();
            Destroy(this.gameObject);
        }
    }
}
