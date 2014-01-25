using UnityEngine;
using System.Collections;

[System.Serializable]
public class RangeAttack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject ApplePrefab;   
    public float m_AttackDelay = 0.3f;
    private int m_AttackRange = 7;
    private GameObject m_Player1;
    private GameObject m_Player2;
    public float m_CurrentAttackDelay = 0.0f;
    private bool m_CanAttack = true;
    private AttackChoise m_AttackChoise;
    private float m_distance1;
    private float m_distance2;

    void Start()
    {     
        m_CurrentAttackDelay = m_AttackDelay;

        if (tag != "Player")
        {
            m_Player1 = GameObject.Find("Player1");
            m_Player2 = GameObject.Find("Player2");
            m_AttackChoise = GetComponent<AttackChoise>();
        }       
    }

    void Update()
    {
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
            if(name == "Player1"
               && m_CanAttack
               && (Input.GetButtonDown("MainAction") || Input.GetAxis("Triggers") < 0))
            {
                Attack();
            }

            else if (name == "Player2"
              && m_CanAttack
              && (Input.GetButtonDown("MainAction") || Input.GetAxis("Triggers") < 0))
            {
                Attack();
            } 
        }
               
        else if (m_AttackChoise.m_current == CurrentAttack.ranged
            && m_CanAttack
            && m_AttackChoise.m_TargerDistance < m_AttackRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        m_CanAttack = false;
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

                    PlayerChartacter target;
                    if (m_distance1 < m_distance2)
                    {
                        target = CharacterChanger.instance.m_PlayerCharacter1;
                    }

                    else
                    {
                        target = CharacterChanger.instance.m_PlayerCharacter2;
                    }

                    switch (target)
                    {
                        case PlayerChartacter.baby:
                            ObjectPool.instance.Instantiate(ProjectilePrefab, Startposition, rotation);
                            break;
                        case PlayerChartacter.hipster:
                            ObjectPool.instance.Instantiate(ApplePrefab, Startposition, rotation);
                            break;
                        case PlayerChartacter.granny:
                            ObjectPool.instance.Instantiate(ProjectilePrefab, Startposition, rotation);
                            break;
                    }
                }
                break;

            case "Player":                
                 {  
                     Startposition = transform.FindChild("ProjectileStart").transform.position;
                     rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,
                     transform.rotation.eulerAngles.y,
                     transform.rotation.eulerAngles.z));

                     PlayerChartacter target;
                     if (name == "Player1")
                     {
                         target = CharacterChanger.instance.m_PlayerCharacter1;
                     }

                     else
                     {
                         target = CharacterChanger.instance.m_PlayerCharacter2;
                     }

                     switch (target)
                    {
                        case PlayerChartacter.baby:
                            ObjectPool.instance.Instantiate(ProjectilePrefab, Startposition, rotation);
                            break;
                        case PlayerChartacter.hipster:
                            ObjectPool.instance.Instantiate(ApplePrefab, Startposition, rotation);
                            break;
                            case PlayerChartacter.granny:
                            ObjectPool.instance.Instantiate(ProjectilePrefab, Startposition, rotation);
                            break;
                    }
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
}
