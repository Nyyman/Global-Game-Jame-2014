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
        m_PlayerCharacter2 = PlayerChartacter.baby;
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
	}
	
    public void SetCharacter(PlayerChartacter type, string nimi)
    {
        if (m_Player1 == null
           || (PlayerSpawner.instance.m_PlayerAmount == 2 && m_Player2 == null))
        {
            GetPlayers();
        }

        m_PlayerCharacter1 = type;

        switch (nimi)
        {
            case "Player1":
                m_PlayerCharacter1 = type;
                switch (type)
                {
                    case PlayerChartacter.baby:
                        m_Player1.transform.FindChild("Body0").gameObject.SetActive(false);
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
                        m_Player2.transform.FindChild("Body0").gameObject.SetActive(false);
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
