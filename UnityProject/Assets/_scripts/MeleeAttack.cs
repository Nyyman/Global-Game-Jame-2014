﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class MeleeAttack : MonoBehaviour 
{
    public int m_Damage = 10;
    public float m_AttackDelay = 3;
    private float m_AttackRange = 1.6f;
    private GameObject m_Player1;
    private GameObject m_Player2;
    private float m_CurrentAttackDelay = 0;
    private bool m_CanAttack = true;    
    private AttackChoise m_AttackChoise;
    private float m_distance1;
    private float m_distance2;
    private bool m_MeleeAttack = false;

	void Start () 
    {
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
        m_CurrentAttackDelay = m_AttackDelay;
        m_AttackChoise = GetComponent<AttackChoise>();
	}

	void Update () 
    {
        m_MeleeAttack = false;

        if (tag != "Player")
        {
            m_distance1 = GetComponent<NavigationScript>().DistanceToPlayer1();
            if (PlayerSpawner.instance.m_PlayerAmount == 2)
            {
                m_distance2 = GetComponent<NavigationScript>().DistanceToPlayer2();
            }
        }

        if (!m_CanAttack)
        {
            UpdateAttackDelay();
        }

        if (tag == "Player")
        {
            if (name == "Player1"
               && m_CanAttack
               && (Input.GetButtonDown("AltAction") || Input.GetAxis("Triggers") < 0))
            {
                Attack();
            }

            else if (name == "Player2"
              && m_CanAttack
              && (Input.GetButtonDown("AltAction") || Input.GetAxis("Triggers") < 0))
            {
                Attack();
            }
        }

        if (m_distance1 < m_AttackRange
            || m_distance2 < m_AttackRange
            && m_CanAttack
            && m_AttackChoise.m_current == CurrentAttack.melee)
        {
            Attack();
        }
	}

    void Attack()
    {
        m_CanAttack = false;

        switch (tag)
        {
            case "Enemy":
                {
                    if (PlayerSpawner.instance.m_PlayerAmount == 2
                    && m_distance2 < m_distance1)
                    {
                        m_Player2.GetComponent<Health>().TakeDamage(m_Damage);
                    }

                    else
                    {
                        m_Player1.GetComponent<Health>().TakeDamage(m_Damage);
                    }

                    GetComponent<AttackChoise>().ChooseNextAttack();

                    GetComponent<NavMeshAgent>().enabled = false;
                }
                break;

            case "Player":
                {
                    m_MeleeAttack = true;
                }
                break;
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
        if (tag == "Enemy")
        {
            GetComponent<NavMeshAgent>().enabled = true;

            if (PlayerSpawner.instance.m_PlayerAmount == 2 
                && m_distance2 < m_distance1)
            {
                transform.LookAt(m_Player2.transform.position);
            }

            else
            {
                transform.LookAt(m_Player1.transform.position);
            }
            
        }
    }

    public float GetAttackRange()
    {
        return m_AttackRange;
    }

    void OnTriggerEnter(Collider col)
    {
        if (m_MeleeAttack 
            && col.GetComponent<Health>() != null)
        {            
            col.GetComponent<Health>().TakeDamage(m_Damage);          
        }
    }
}
