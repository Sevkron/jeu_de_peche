using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] woodClips;
    [SerializeField]
    private AudioClip[] snowClips;
    [SerializeField]
    private AudioClip[] dirtClips;

    public AudioClip sfxPickup;

    private AudioSource audioSource;

    private CharacterController characterController;
    private GameMaster gm;
    //private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = this.GetComponent<CharacterController>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //terrainDetector = new TerrainDetector();
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
        return snowClips[UnityEngine.Random.Range(0, snowClips.Length)];

        //DetectTerrain
        /*int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 0:
                return woodClips[UnityEngine.Random.Range(0, woodClips.Length)];
            case 1:
                return snowClips[UnityEngine.Random.Range(0, snowClips.Length)];
            case 2:
            default:
                return dirtClips[UnityEngine.Random.Range(0, dirtClips.Length)];
        }*/

    }
}