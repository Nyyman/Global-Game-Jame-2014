using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EnemySpawner : MonoBehaviour 
{
    GameObject[] allEnemies;
    public GameObject m_EnemyPrefab;
    private int[] m_MaxEnemyAmounts = {3, 4, 6, 8, 10};
    private int m_EnemyAmountIndex = 0;
    //public float m_SpawDelay = 3;
    //private float m_CurrentDelay;
    //private bool m_CanSpawn = false;
    private bool m_CurrentEnemyAmount;
    private GameObject m_PlayerSpawner;
    private List<GameObject> m_Spawnlocations = new List<GameObject>();
	
	void Start ()
    {
        m_PlayerSpawner = GetComponent<PlayerSpawner>().gameObject;
        //m_CurrentDelay = m_SpawDelay;
        
	}	
	
	void Update () 
    {
        if (Application.loadedLevel == 1
            && m_Spawnlocations.Count == 0)
        {
            GetSpawnLocations();
        }

        //if (!m_CanSpawn)
        //{
        //    UpdateSpawnDelay();
        //}

        //else
        //{
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (m_PlayerSpawner.GetComponent<PlayerSpawner>().m_PlayersSpawned && allEnemies.Length == 0)
            {
                SpawnEnemy();
            }
        //}
	}

    //void UpdateSpawnDelay()
    //{
    //    //m_CurrentDelay -= Time.deltaTime;

    //    //if (m_CurrentDelay <= 0)
    //    //{
    //    //    CanSpawn();
    //    //}

    //    if (m_CurrentDelay <= 0)
    //    {
    //        CanSpawn();
    //    }
    //}

    //void CanSpawn()
    //{
    //    //m_CurrentDelay = m_SpawDelay;
    //    //m_CanSpawn = true;
    //}

    void SpawnEnemy()
    {
        int max;
        if (m_EnemyAmountIndex > m_MaxEnemyAmounts.Length)
        {
            max = 15;
        }

        else
        {
            max = m_MaxEnemyAmounts[m_EnemyAmountIndex];
            ++m_EnemyAmountIndex;
        }

        for (int i = 0; i < max; ++i)
        {
            int random = Random.Range(0, m_Spawnlocations.Count);

            Vector3 position = m_Spawnlocations[random].transform.position;

            ObjectPool.instance.Instantiate(m_EnemyPrefab, position, new Quaternion(0, 0, 0, 0));
        }

       
       // m_CanSpawn = false;
    }

    void GetSpawnLocations()
    {
        Transform AllLocations = GameObject.Find("SpawnLocations").transform;

        foreach (Transform child in AllLocations)
        {
            m_Spawnlocations.Add(child.gameObject);
        }
    }
}
