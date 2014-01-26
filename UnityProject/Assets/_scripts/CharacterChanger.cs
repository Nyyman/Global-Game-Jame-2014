using UnityEngine;
using System.Collections;

public enum PlayerChartacter
{
    baby, 
    hipster,
    granny
}

public class CharacterChanger : MonoBehaviour 
{
    public static CharacterChanger instance;
    public PlayerChartacter m_PlayerCharacter1;
    public PlayerChartacter m_PlayerCharacter2;
    GameObject m_Player1;
    GameObject m_Player2;

    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
        m_PlayerCharacter1 = PlayerChartacter.baby;
        m_PlayerCharacter2 = PlayerChartacter.hipster;
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
	}

    public void SetNextCharacter(string name)
    {
        PlayerChartacter type;        

        switch (name)
        {
            case "Player1":
                type = m_PlayerCharacter1;
                switch (PlayerSpawner.instance.m_PlayerAmount)
                {
                    case 1:
                        Debug.Log(m_PlayerCharacter1);
                        switch (type)
                        {                                
                            case PlayerChartacter.baby:
                                m_PlayerCharacter1 = PlayerChartacter.hipster;
                                break;

                            case PlayerChartacter.hipster:
                                m_PlayerCharacter1 = PlayerChartacter.granny;
                                break;

                            case PlayerChartacter.granny:
                                m_PlayerCharacter1 = PlayerChartacter.baby;
                                break;
                        }

                        break;

                    case 2:
                         switch (type)
                        {
                            case PlayerChartacter.baby:
                                if (m_PlayerCharacter2 != PlayerChartacter.hipster)
                                {
                                    m_PlayerCharacter1 = PlayerChartacter.hipster;
                                }

                                else
                                {
                                    m_PlayerCharacter1 = PlayerChartacter.granny;
                                }
                                break;

                            case PlayerChartacter.hipster:
                                if (m_PlayerCharacter2 != PlayerChartacter.granny)
                                {
                                    m_PlayerCharacter1 = PlayerChartacter.granny;
                                }

                                else
                                {
                                    m_PlayerCharacter1 = PlayerChartacter.baby;
                                }
                                break;

                            case PlayerChartacter.granny:
                                if (m_PlayerCharacter2 != PlayerChartacter.baby)
                                {
                                    m_PlayerCharacter1 = PlayerChartacter.baby;
                                }

                                else
                                {
                                    m_PlayerCharacter1 = PlayerChartacter.hipster;
                                }
                                break;
                        }
                        break;
                }
                SetCharacter(m_PlayerCharacter1, "Player1");
                break;

            case "Player2":
                type = m_PlayerCharacter2;
                switch (type)
                {
                    case PlayerChartacter.baby:
                        if (m_PlayerCharacter1 != PlayerChartacter.hipster)
                        {
                            m_PlayerCharacter2 = PlayerChartacter.hipster;
                        }

                        else
                        {
                            m_PlayerCharacter2 = PlayerChartacter.granny;
                        }
                        break;

                    case PlayerChartacter.hipster:
                        if (m_PlayerCharacter1 != PlayerChartacter.granny)
                        {
                            m_PlayerCharacter2 = PlayerChartacter.granny;
                        }

                        else
                        {
                            m_PlayerCharacter2 = PlayerChartacter.baby;
                        }
                        break;

                    case PlayerChartacter.granny:
                        if (m_PlayerCharacter1 != PlayerChartacter.baby)
                        {
                            m_PlayerCharacter2 = PlayerChartacter.baby;
                        }

                        else
                        {
                            m_PlayerCharacter2 = PlayerChartacter.hipster;
                        }
                        break;
                }
                SetCharacter(m_PlayerCharacter2, "Player2");
                break;
        }

    }
	
    public void SetCharacter(PlayerChartacter type, string name)
    {
        if (m_Player1 == null
           || (PlayerSpawner.instance.m_PlayerAmount == 2 && m_Player2 == null))
        {
            GetPlayers();
        }

        m_PlayerCharacter1 = type;

        switch (name)
        {
            case "Player1":
                m_PlayerCharacter1 = type;
                switch (type)
                {
                    case PlayerChartacter.baby:
                        m_Player1.transform.FindChild("Body0").gameObject.SetActive(true);
                        m_Player1.transform.FindChild("Body1").gameObject.SetActive(false);
                        m_Player1.transform.FindChild("Body2").gameObject.SetActive(false);
                        break;

                    case PlayerChartacter.hipster:
                        m_Player1.transform.FindChild("Body0").gameObject.SetActive(false);
                        m_Player1.transform.FindChild("Body1").gameObject.SetActive(true);
                        m_Player1.transform.FindChild("Body2").gameObject.SetActive(false);
                        break;

                    case PlayerChartacter.granny:
                        m_Player1.transform.FindChild("Body0").gameObject.SetActive(false);
                        m_Player1.transform.FindChild("Body1").gameObject.SetActive(false);
                        m_Player1.transform.FindChild("Body2").gameObject.SetActive(true);
                        break;
                }
                break;

            case "Player2":
                m_PlayerCharacter2 = type;
                switch (type)
                {
                    case PlayerChartacter.baby:
                        m_Player2.transform.FindChild("Body0").gameObject.SetActive(true);
                        m_Player2.transform.FindChild("Body1").gameObject.SetActive(false);
                        m_Player2.transform.FindChild("Body2").gameObject.SetActive(false);
                        break;

                    case PlayerChartacter.hipster:
                        m_Player2.transform.FindChild("Body0").gameObject.SetActive(false);
                        m_Player2.transform.FindChild("Body1").gameObject.SetActive(true);
                        m_Player2.transform.FindChild("Body2").gameObject.SetActive(false);
                        break;

                    case PlayerChartacter.granny:
                        m_Player2.transform.FindChild("Body0").gameObject.SetActive(false);
                        m_Player2.transform.FindChild("Body1").gameObject.SetActive(false);
                        m_Player2.transform.FindChild("Body2").gameObject.SetActive(true);
                        break;
                }
                break;
        }
    }

    void GetPlayers()
    {
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
    }
}
