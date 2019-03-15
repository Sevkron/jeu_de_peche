﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using Cinemachine;


public class VCamVolumeTrigger : MonoBehaviour {

    public CinemachineVirtualCamera m_VCam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CameraManager.Instance.SetVCamActive(m_VCam);
        }
    }
}
