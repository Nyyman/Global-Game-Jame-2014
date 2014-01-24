using UnityEngine;
using System.Collections;

[System.Serializable]
public class Health : MonoBehaviour 
{
    public int m_HealthMax = 10;
    public int m_CurrentHealth;

	void Start () 
    {
        m_CurrentHealth = m_HealthMax;
	}
	
	void Update () 
    {
	    
	}

    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;
        ClampHealth();
    }

    void ClampHealth()
    {
        if (m_CurrentHealth < 0)
        {
            ObjectPool.instance.Destroy(this.gameObject, 0.1f);
            m_CurrentHealth = 0;
        }

        if (m_CurrentHealth >= m_HealthMax)
        {
            m_CurrentHealth = m_HealthMax;
        }
    }
}
