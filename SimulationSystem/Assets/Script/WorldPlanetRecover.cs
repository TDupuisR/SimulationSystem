using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlanetRecover : MonoBehaviour
{
    [SerializeField] GameObject[] m_planetList;
    PlanetBehavior[] m_planetScriptList;

    public GameObject[] PlanetList { get => m_planetList; }
    public PlanetBehavior[] PlanetScriptList { get => m_planetScriptList; }

    private void Start()
    {
        for (int i = 0; i < m_planetList.Length; i++)
        {
            m_planetScriptList[i] = m_planetList[i].GetComponent<PlanetBehavior>();
        }
    }
}
