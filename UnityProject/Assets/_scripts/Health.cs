using UnityEngine;
using System.Collections;

[System.Serializable]
public class Health : MonoBehaviour 
{
    public int m_HealthMax = 10;
    public int m_CurrentHealth;
    public GameObject m_GUIHealth1;
    public GameObject m_GUIHealth2; 

	void Start () 
    {
        m_CurrentHealth = m_HealthMax;
        m_GUIHealth1 = GameObject.Find("GUI").transform.FindChild("Health1").gameObject;
        m_GUIHealth2 = GameObject.Find("GUI").transform.FindChild("Health2").gameObject;
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
            m_CurrentHealth = 0;
            if (tag != "Player")
            {
                ObjectPool.instance.Destroy(this.gameObject, 0.1f);
            }

            else
            {
                //TODO
                //GAME OVER
            }

        }

        if (m_CurrentHealth >= m_HealthMax)
        {
            m_CurrentHealth = m_HealthMax;
        }


        if (name == "Player1")
        {
            m_GUIHealth1.GetComponent<GUIHealth1>().UpdateUI();
        }

        if (name == "Player2")
        {
            m_GUIHealth2.GetComponent<GUIHealth2>().UpdateUI();
        }
    }

    public int GetHealth()
    {
        return m_CurrentHealth;
    }
}
