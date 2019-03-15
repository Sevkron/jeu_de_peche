using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour
{
    private float maxLanternLight = 50f;
    private float minLanternLight = 0f;
    public float currentLanternLight;
    private Light lanternLight;
    private float t;

    public GameObject Hand;
    // Start is called before the first frame update
    void Start()
    {
        lanternLight = GetComponentInChildren<Light>();
        currentLanternLight = maxLanternLight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lanternLight.intensity = currentLanternLight;
        LightIntensity();
        gameObject.transform.position = Hand.transform.position;
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
        currentLanternLight += 25f;
    }
    public void AddFullLightIntensity()
    {
        currentLanternLight = maxLanternLight;
    }
}
