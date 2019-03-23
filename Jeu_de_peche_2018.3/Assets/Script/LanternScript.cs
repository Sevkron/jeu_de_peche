using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour
{
    private float maxLanternLight = 100f;
    private float minLanternLight = 0f;
    public float currentLanternLight;
    private Light lanternLight;
    private float t;
    private GameObject GMA;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        lanternLight = GetComponentInChildren<Light>();
        currentLanternLight = maxLanternLight;
        GMA = GameObject.FindGameObjectWithTag("GM");
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lanternLight.intensity = currentLanternLight;
        LightIntensity();

        if (currentLanternLight <= 20 && Player.GetComponentInChildren<Diary_Pause_Menu>().DiaryCanvasActive == false)
        {
            GMA.GetComponent<GameMaster>().AfficherAX();
        }

        else if (currentLanternLight >= 20)
        {
            GMA.GetComponent<GameMaster>().EnleverAX();
        }
    }

    void LightIntensity()
    {
        t = Time.time / 200;
        currentLanternLight = currentLanternLight - 0.1f * Time.deltaTime;
        //Debug.Log("LightTime =" + t);
        if(currentLanternLight <= minLanternLight)
        {
            currentLanternLight = minLanternLight;
        }else if(currentLanternLight >= maxLanternLight)
        {
            currentLanternLight = maxLanternLight;
        }
    }

    public void AddLightIntensity()
    {
        currentLanternLight += 50f;
    }
    public void AddFullLightIntensity()
    {
        currentLanternLight = maxLanternLight;
    }
}
