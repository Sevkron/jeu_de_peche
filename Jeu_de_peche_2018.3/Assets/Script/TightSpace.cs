using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;

public class TightSpace : MonoBehaviour
{
    private bool isInTightSpace;
    private Rigidbody playerRigidbody;
    public GameObject GOPlayerPos;
    private Transform PlayerPos;
    private GameObject player;
    private PlayableDirector betweenTwoWalls;
    // Start is called before the first frame update
    void Start()
    {
        betweenTwoWalls = this.GetComponent<PlayableDirector>();
        PlayerPos = this.gameObject.transform.Find("PlayerPos");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            //player.GetComponent<Animator>().enabled = false;
            GOPlayerPos.SetActive(true);
            GOPlayerPos.GetComponent<PlayerCinematicOverride>().Player = player;
            betweenTwoWalls.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<CharacterController>().enabled = true;
            GOPlayerPos.SetActive(false);
            //player.GetComponent<Animator>().enabled = true;
        }
    }
}
