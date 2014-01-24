using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeleeAttack : MonoBehaviour 
{
    public int m_Damage = 10;
    public int m_AttackDelay = 3;
    public int m_AttackRange = 1;
    private GameObject m_Player;    
    private float m_CurrentAttackDelay = 0;
    private bool m_CanAttack = true;    

	void Start () 
    {
        m_Player = GameObject.Find("Player");
        m_CurrentAttackDelay = m_AttackDelay;
	}

	void Update () 
    {
        if (!m_CanAttack)
        {
            UpdateAttackDelay();
        }

        if (Vector3.Distance(transform.position, m_Player.transform.position) < m_AttackRange
            && m_CanAttack)
        {
            Attack();
        }
	}

    void Attack()
    {
        m_Player.GetComponent<Health>().TakeDamage(m_Damage);
        m_CanAttack = false;
    }

    void UpdateAttackDelay()
    {
        m_CurrentAttackDelay -= Time.deltaTime;

        if (m_CurrentAttackDelay <= 0)
        {
            CanAttack();
        }
    }

    void CanAttack()
    {
        m_CurrentAttackDelay = m_AttackDelay;
        m_CanAttack = true;
    }

   

    
}
