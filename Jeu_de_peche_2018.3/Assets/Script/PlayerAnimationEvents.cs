using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    public bool m_IsWood = false;
    [SerializeField]
    private AudioClip[] woodClips;
    [SerializeField]
    private AudioClip[] snowClips;

    public AudioClip sfxPickup;

    private AudioSource audioSource;

    private CharacterController characterController;
    private GameMaster gm;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = this.GetComponent<CharacterController>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void WaitForAnimStart()
    {
        characterController.enabled = false;
    }

    private void WaitForRespawn()
    {
        gm.Respawn();
    }

    private void WaitForAnimEnd()
    {
        characterController.enabled = true;
    }

    private void SFXPickup()
    {
        AudioClip clip = sfxPickup;
        audioSource.PlayOneShot(clip);
    }

    private void Step()
    {
        AudioClip clip = GetRandomStepClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomStepClip()
    {
        if(m_IsWood == true)
        {
            return woodClips[UnityEngine.Random.Range(0, woodClips.Length)];
        }
        else
        {
            return snowClips[UnityEngine.Random.Range(0, snowClips.Length)];
        }
    }
}