using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlanetRecover : MonoBehaviour
{
    [SerializeField] GameObject[] m_planetList;
    PlanetBehavior[] m_planetScriptList;

    [SerializeField] float m_GPower = -11f; //Initially must be -11

    public GameObject[] PlanetList { get => m_planetList; }
    public PlanetBehavior[] PlanetScriptList { get => m_planetScriptList; }
    public float GPower { get => m_GPower; }

    private void Awake()
    {
        m_planetScriptList = new PlanetBehavior[m_planetList.Length];

        for (int i = 0; i < m_planetList.Length; i++)
        {
            m_planetScriptList[i] = m_planetList[i].GetComponent<PlanetBehavior>();
        }
    }
}
