using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeleeAttack : MonoBehaviour 
{
    public int m_Damage = 10;
    public int m_AttackDelay = 3;
    private float m_AttackRange = 1.6f;
    private GameObject m_Player;    
    private float m_CurrentAttackDelay = 0;
    private bool m_CanAttack = true;    
    private AttackChoise m_AttackChoise;

	void Start () 
    {
        m_Player = GameObject.Find("Player");
        m_CurrentAttackDelay = m_AttackDelay;
        m_AttackChoise = GetComponent<AttackChoise>();
	}

	void Update () 
    {
        if (!m_CanAttack)
        {
            UpdateAttackDelay();
        }

        if (Vector3.Distance(transform.position, m_Player.transform.position) < m_AttackRange
            && m_CanAttack
            && m_AttackChoise.m_current == CurrentAttack.melee)
        {
            Attack();
        }
	}

    void Attack()
    {
        m_Player.GetComponent<Health>().TakeDamage(m_Damage);
        GetComponent<AttackChoise>().ChooseNextAttack();
        m_CanAttack = false;

        if (name == "Enemy")
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
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
        if (name == "Enemy")
        {
            GetComponent<NavMeshAgent>().enabled = true;
            transform.LookAt(m_Player.transform.position);
        }
    }

    public float GetAttackRange()
    {
        return m_AttackRange;
    }
}
