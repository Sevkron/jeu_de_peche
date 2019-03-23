using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Cutscene;
    public bool doneCinematic;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(doneCinematic == true)
            {
                m_Cutscene.SetActive(false);
                Destroy(this);
            }
            else
            {
                m_Cutscene.SetActive(true);
                Destroy(this);
            }
        }
    }
}
