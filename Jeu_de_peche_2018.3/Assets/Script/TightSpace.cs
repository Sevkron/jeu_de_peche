using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TightSpace : MonoBehaviour
{
    private bool isInTightSpace;
    private Rigidbody playerRigidbody;
    private Transform outsidePos;
    private Transform insidePos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        outsidePos = this.transform.Find("OutsidePos");
        insidePos = this.transform.Find("InsidePos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            isInTightSpace = player.GetComponent<CharacterController>().m_isInTightSpace;
            playerRigidbody = player.GetComponent<Rigidbody>();
            if (isInTightSpace == false)
            {
                GoesIntoTightSpace();
            }
            else
            {
                player.GetComponent<CharacterController>().m_isInTightSpace = false;
                player.GetComponent<Animator>().SetBool("IsInTightSpace", false);
            }
        }
    }

    private void GoesIntoTightSpace()
    {
        player.GetComponent<CharacterController>().m_isInTightSpace = true;
        player.GetComponent<Animator>().SetBool("IsInTightSpace", true);
        DOTween.Sequence()
            .Append(playerRigidbody.DOMove(outsidePos.position, 1))
            //.Append(playerRigidbody.DORotate(outsidePos.position, 1))
            .Append(playerRigidbody.DOMove(insidePos.position, 1));
            //.Append(playerRigidbody.DORotate(insidePos.position, 1));
    }
}
