using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Play()
    {
        player.GetComponent<Animator>().SetBool("HasStart", true);
        this.gameObject.SetActive(false);
    }
}
