using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear_Manager : MonoBehaviour
{
    public float m_currentFearLevel = 0;

    private float minFear = 0;
    private float maxFear = 100;

    public GameObject m_Lantern;
    private GameMaster gm;
    private float fearModifier;
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
        currentLight = m_Lantern.GetComponent<LanternScript>().currentLanternLight;
        m_currentFearLevel = m_currentFearLevel + fearModifier * Time.deltaTime;
        if (currentLight >= 25 && m_currentFearLevel > minFear)
        {
            fearModifier = -1f;
        }else if(currentLight < 25 && currentLight > 10)
        {
            fearModifier = 1f;
        }
        else if(currentLight <= 10)
        {
            fearModifier = fearModifier + 0.2f ;
        }
        else
        {
            fearModifier = 0;
        }

        if(m_currentFearLevel >= maxFear)
        {
            //GetComponentInParent
            Debug.Log("You Dead");

            this.transform.position = gm.lastCheckPointPos;
            m_currentFearLevel = minFear;
        }
    }
}
