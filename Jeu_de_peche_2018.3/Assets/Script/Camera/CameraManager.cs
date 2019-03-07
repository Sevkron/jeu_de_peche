using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour {

    public static CameraManager Instance;


    private List<CinemachineVirtualCamera> _VCams;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        _VCams = new List<CinemachineVirtualCamera>(GameObject.FindObjectsOfType<CinemachineVirtualCamera>());

    }


    public void SetVCamActive(int a_Index)
    {
        if (a_Index>=0 && a_Index< _VCams.Count)
            SetVCamActive(_VCams[a_Index]);
    }

    public void SetVCamActive (CinemachineVirtualCamera a_VCam)
    {
        foreach (CinemachineVirtualCamera cam in _VCams)
            if (cam == a_VCam)
                cam.Priority = 100;
            else
                cam.Priority = -1;
    }
   
    public CinemachineVirtualCamera GetActiveVirtualCameraForward ()
    {
        return (CinemachineVirtualCamera) Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera;
        
    }
}
