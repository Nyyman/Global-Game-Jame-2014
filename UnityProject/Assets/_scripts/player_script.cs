using UnityEngine;
using System.Collections;

public class player_script : MonoBehaviour
{
    public bool m_collides = false;
    public GameObject m_floor;
    public GameObject m_player;

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject == m_floor) &&
            !(collision.gameObject == m_player))
        {
            //Debug.Log(collision.gameObject.name);
            m_collides = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
       
    }

    void OnCollisionExit(Collision collision)
    {
        m_collides = false;
    }
}
