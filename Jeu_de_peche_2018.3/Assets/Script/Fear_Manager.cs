using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear_Manager : MonoBehaviour
{
    public float m_currentFearLevel = 0;
    public GameObject m_Lantern;
    private GameMaster gm;
    private float currentLight;
    // Start is called before the first frame update
    void Start()
    {
        //m_currentFearLevel = 0;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentLight = GetComponent<LanternScript>().currentLanternLight;
        if (currentLight >= 25)
        {
            m_currentFearLevel = m_currentFearLevel - 0.1f * Time.deltaTime;
        }else if(currentLight < 25 && currentLight > 10)
        {
            m_currentFearLevel = m_currentFearLevel + 0.1f * Time.deltaTime;
        }
        else
        {
            m_currentFearLevel = m_currentFearLevel - 0.2f * Time.deltaTime;
        }

        if(m_currentFearLevel == 100)
        {
            this.transform.position = gm.lastCheckPointPos;
        }
    }
}
