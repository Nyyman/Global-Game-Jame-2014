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
    private float m_TargerDistance;
    private GameObject m_Player;

    void Start()
    {
        m_Player = GameObject.Find("Player");
        CalculateTargetDistance();
        ChooseNextAttack();
    }

    void CalculateTargetDistance()
    {
        m_TargerDistance = Vector3.Distance(transform.position, m_Player.transform.position);
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
