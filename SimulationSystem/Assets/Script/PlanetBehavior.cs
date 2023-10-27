using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    [SerializeField] WorldPlanetRecover m_recoverPlanetList;

    [SerializeField] PlanetBehavior[] m_moonList;
    [SerializeField] PlanetBehavior m_orbitCenter;

    [SerializeField] Rigidbody m_rb;

    PlanetBehavior[] m_planetList = { };
    int m_lenPlanetList;
    int m_exeptionIndex;

    float m_GConst = 6.7f;
    [SerializeField] bool m_isClockwise = false;

    [Header("Public Info")]
    public float _masse;

    private void Start()
    {
        //Variables set
        m_planetList = m_recoverPlanetList.PlanetScriptList;
        m_lenPlanetList = m_planetList.Length;

        m_rb.mass = _masse;

        m_GConst = m_GConst * Mathf.Pow(10, m_recoverPlanetList.GPower);

        for (int i = 0; i < m_lenPlanetList; i++)
        {
            if (m_planetList[i].transform == gameObject.transform) m_exeptionIndex = i;
        }


        //Initial Velocity set
        if (m_orbitCenter != null) OrbiteForce();
        else m_rb.velocity = Vector3.zero;

        for (int i = 0; i < m_moonList.Length; i++)
        {
            m_moonList[i].AddVelocity(m_rb.velocity);
        }
    }

    private void OrbiteForce()
    {
        float speed = Mathf.Sqrt(m_GConst * m_orbitCenter._masse / Distance(m_orbitCenter)); //v0 = sqrt(G * m2 / r)

        Vector3 direction = Vector3.Normalize(m_orbitCenter.transform.position - transform.position);
        if (m_isClockwise) direction = new Vector3(-direction.z, direction.y, direction.x); //Clockwise rotation
        else direction = new Vector3(direction.z, direction.y, -direction.x); //Anti-Clockwise rotation

        m_rb.velocity = speed * direction;
    }

    public void AddVelocity(Vector3 velocity) { m_rb.velocity += velocity; }


    private void FixedUpdate()
    {
        Vector3 force = Vector3.zero;
        for (int i = 0; i < m_lenPlanetList; i++)
        {
            if (i != m_exeptionIndex) force += Force(Distance(m_planetList[i]), i);
        }

        m_rb.AddForce(force);
    }

    private Vector3 Force(float distance, int index)
    {
        float Force = m_GConst * (_masse * m_planetList[index]._masse / (distance * distance)); //F = G * (m1 * m2 / r²)
        float acceleration = Force;

        Vector3 direction = Vector3.Normalize(m_planetList[index].transform.position - transform.position) * acceleration;

        return direction;
    }

    private float Distance(PlanetBehavior target)
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }
}
