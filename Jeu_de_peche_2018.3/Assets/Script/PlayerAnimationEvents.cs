﻿using System.Collections;
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

    private AudioSource audioSource;
    //private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //terrainDetector = new TerrainDetector();
    }

    private void SFXPickup()
    {

    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
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