using UnityEngine;
using System.Collections;

public enum CurrentAttack
{
    melee,
    ranged,
    none
}

[System.Serializable]
public class AttackChoise : MonoBehaviour 
{
    public bool m_HasRangedAttack = true;
    public bool m_HasMeleeAttack = true;
    public CurrentAttack m_current;
    public float m_TargerDistance;
    private GameObject m_Player1;
    private GameObject m_Player2;

    void Start()
    {
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
        CalculateTargetDistance();
        ChooseNextAttack();
    }

    void CalculateTargetDistance()
    {
        float distance1 = Vector3.Distance(transform.position, m_Player1.transform.position);
        if (PlayerSpawner.instance.m_PlayerAmount == 2)
        {
            float distance2 = Vector3.Distance(transform.position, m_Player2.transform.position);
            m_TargerDistance = (Mathf.Min(distance1, distance2));
        }

        else
        {
            m_TargerDistance = distance1;
        }
    }

    public void ChooseNextAttack()
    {
        if (m_HasRangedAttack && m_TargerDistance >= GetComponent<RangeAttack>().GetAttackRange() - 2)
        {
            m_current = CurrentAttack.ranged;
        }

        else if (m_HasMeleeAttack)
        {
            m_current = CurrentAttack.melee;
        }

        else if (m_HasRangedAttack)
        {
            m_current = CurrentAttack.ranged;
        }

        else 
        {
            m_current = CurrentAttack.none;
        }
    }
}
