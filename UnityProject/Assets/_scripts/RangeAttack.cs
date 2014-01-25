using UnityEngine;
using System.Collections;

[System.Serializable]
public class RangeAttack : MonoBehaviour
{
    public GameObject ProjectilePrefab;    
    public float m_AttackDelay = 3;
    private int m_AttackRange = 7;
    private GameObject m_Player;
    private float m_CurrentAttackDelay = 0;
    private bool m_CanAttack = true;
    private AttackChoise m_AttackChoise;

    void Start()
    {        
        m_CurrentAttackDelay = m_AttackDelay;

        if (name != "Player")
        {
            m_Player = GameObject.Find("Player");
            m_AttackChoise = GetComponent<AttackChoise>();
        }       
    }

    void Update()
    {
        if (!m_CanAttack)
        {
            UpdateAttackDelay();
        }

        if (name == "Player")
        {
            if(m_CanAttack)
            {
                Attack();
            } 
        }
               
        else if (m_AttackChoise.m_current == CurrentAttack.ranged
            && m_CanAttack
            && Vector3.Distance(transform.position, m_Player.transform.position) < m_AttackRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        Vector3 Startposition;
        Quaternion rotation;

        switch (tag)
        {
            case "Enemy":
                {
                    Startposition = transform.FindChild("ProjectileStart").transform.position;
                    rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,
                    transform.rotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z));
                    ObjectPool.instance.Instantiate(ProjectilePrefab, Startposition, rotation);
                    m_CanAttack = false;
                    GetComponent<AttackChoise>().ChooseNextAttack();
                    GetComponent<NavMeshAgent>().enabled = false;
                }
                break;

            case "Player":
                if (Input.GetButtonDown("MainAction"))
                 {  
                     Startposition = transform.FindChild("ProjectileStart").transform.position;
                     rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,
                     transform.rotation.eulerAngles.y,
                     transform.rotation.eulerAngles.z));
                     ObjectPool.instance.Instantiate(ProjectilePrefab, Startposition, rotation);
                     m_CanAttack = false;
                 }
                break;
            default:
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
