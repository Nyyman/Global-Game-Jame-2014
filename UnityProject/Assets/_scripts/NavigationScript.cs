using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NavigationScript : MonoBehaviour 
{
    private List<GameObject> m_NavigationPoints;
    private GameObject m_Player;
    private NavMeshAgent m_NavMeshAgent;
    public float m_NavigationOffset = 0.01f;
    private float m_MeleeRange = 1.6f;
    private float m_MinNavigationDistance = 1.4f;
    private float m_RangeRange = 5.0f;

	void Start () 
    {
        m_MeleeRange = GetComponent<MeleeAttack>().GetAttackRange();
        m_RangeRange = GetComponent<RangeAttack>().GetAttackRange();
        m_NavigationPoints = new List<GameObject>();
        SetNavigationPoints();
        m_Player = GameObject.Find("Player");
        m_NavMeshAgent = GetComponent<NavMeshAgent>();        
        SetNewDestination();
	}	
	
	void Update () 
    {        
        SetNewDestination();       
	}

    void SetNavigationPoints()
    {
        GameObject AllPoints;
        AllPoints = GameObject.Find("NavigationPoints");       
       
        foreach(Transform child in AllPoints.transform)
        {
            m_NavigationPoints.Add(child.gameObject);           
        }
    }

    //bool IsInDestination()
    //{
    //    return (Vector3.Distance(transform.position, m_NavMeshAgent.destination) < m_NavigationOffset);
    //}

    void SetNewDestination()
    {
       //int random = Random.Range(0, m_NavigationPoints.Count);
       //m_NavMeshAgent.destination = m_NavigationPoints[random].transform.position

        if (m_NavMeshAgent.enabled)
        {
            if(DistanceToPlayer() > m_MinNavigationDistance)
            {
                m_NavMeshAgent.destination = m_Player.transform.position;
            }

            else 
            {
                m_NavMeshAgent.destination = transform.position;
            }          
        }

       
    }

    float DistanceToPlayer()
    {
        return (Vector3.Distance(transform.position, m_Player.transform.position));
    }
}
