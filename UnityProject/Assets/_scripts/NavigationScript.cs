using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NavigationScript : MonoBehaviour 
{
    private List<GameObject> m_NavigationPoints;
    private GameObject m_Player1;
    private GameObject m_Player2;
    private GameObject m_ClosestPlayer;
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
        //SetNavigationPoints();
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
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
        SetClosestPlayer();

        if (m_NavMeshAgent.enabled)
        {   
            if(DistanceToClosestPlayer() > m_MinNavigationDistance)
            {
                m_NavMeshAgent.destination = m_ClosestPlayer.transform.position;              
            }

            //else 
            //{
            //    m_NavMeshAgent.destination = transform.position;
            //}          
        }       
    }

    public void SetClosestPlayer()
    {
        if (m_Player1 == null
            || (PlayerSpawner.instance.m_PlayerAmount == 2 && m_Player2 == null))
        {
            GetPlayers();
        }

        float distance1 = DistanceToPlayer1();

        if (PlayerSpawner.instance.m_PlayerAmount == 2)
        {
            float distance2 = DistanceToPlayer2();
            if (distance2 < distance1)
            {
                m_ClosestPlayer = m_Player2;
            }

            else
            {
                m_ClosestPlayer = m_Player1;
            }
        }

        else
            m_ClosestPlayer = m_Player1;
    }

    public float DistanceToPlayer1()
    {
        return (Vector3.Distance(transform.position, m_Player1.transform.position));        
    }

    public float DistanceToPlayer2()
    {
        return (Vector3.Distance(transform.position, m_Player2.transform.position));
    }

    public float DistanceToClosestPlayer()
    {
        return (Vector3.Distance(transform.position, m_ClosestPlayer.transform.position));
    }

    void GetPlayers()
    {
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
    }
}
