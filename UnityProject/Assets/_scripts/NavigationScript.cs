using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NavigationScript : MonoBehaviour 
{
    private List<GameObject> m_NavigationPoints;
    private NavMeshAgent m_NavMeshAgent;
    public float NavigationOffset;

	void Start () 
    {
        m_NavigationPoints = new List<GameObject>();
        SetNavigationPoints();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        NavigationOffset = 0.01f;
        SetNewDestination();
	}	
	
	void Update () 
    {
        if (IsInDestination())
        {
            SetNewDestination();
        }
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

    bool IsInDestination()
    {
        return (Vector3.Distance(transform.position, m_NavMeshAgent.destination) < NavigationOffset);
    }

    void SetNewDestination()
    {
        int random = Random.Range(0, m_NavigationPoints.Count);
        m_NavMeshAgent.destination = m_NavigationPoints[random].transform.position;
    }
}
