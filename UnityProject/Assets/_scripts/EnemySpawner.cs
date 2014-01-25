using UnityEngine;
using System.Collections;

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
	
	void Start ()
    {
        //m_CurrentDelay = m_SpawDelay;
	}	
	
	void Update () 
    {
        //if (!m_CanSpawn)
        //{
        //    UpdateSpawnDelay();
        //}

        //else
        //{
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (allEnemies.Length == 0)
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
            Vector3 position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            ObjectPool.instance.Instantiate(m_EnemyPrefab, position, new Quaternion(0, 0, 0, 0));
        }

       
       // m_CanSpawn = false;
    }
}
