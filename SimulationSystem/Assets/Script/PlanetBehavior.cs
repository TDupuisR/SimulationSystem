using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    [SerializeField] WorldPlanetRecover m_recoverPlanetList;
    [SerializeField] Rigidbody m_rb;

    GameObject[] m_planetList;
    PlanetBehavior[] m_planetScirptList;
    int m_lenPlanetList;

    float gravitationConst = 6.7f * Mathf.Pow(10f, -11f);

    [Header("Public Info")]
    public float masse;
    public Vector3 initialSpeed;

    private void Start()
    {
        m_planetList = m_recoverPlanetList.PlanetList;
        m_planetScirptList = m_recoverPlanetList.PlanetScriptList;

        m_lenPlanetList = m_planetList.Length;
    }

    private void OrbiteForce()
    {

    }

    private Vector3 Force(float distance, int index)
    {
        float Force = gravitationConst * (masse * m_planetScirptList[index].masse / distance);
        float acceleration = Force / masse;

        Vector3 direction = Vector3.Normalize(m_planetList[index].transform.position - transform.position) * acceleration;

        return direction;
    }

    private float Distance(GameObject target)
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x, 2f) +
                          Mathf.Pow(transform.position.y - target.transform.position.y, 2f) +
                          Mathf.Pow(transform.position.z - target.transform.position.z, 2f) );
    }
}
