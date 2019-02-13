using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class textCombustible : MonoBehaviour
{
    public int m_NumberCombustible;
    public Text m_ShowNumberCombustible;

    void Update()
    {
        m_ShowNumberCombustible.text = "" + m_NumberCombustible;
    }
}
