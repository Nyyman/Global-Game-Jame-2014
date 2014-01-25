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
    GameObject m_Player;

    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
        m_Player = GameObject.Find("Player");
	}
	
    public void SetCharacter(PlayerChartacter type)
    {
        switch (type)
        {
            case PlayerChartacter.baby:
                 m_Player.transform.FindChild("Body0").gameObject.SetActive(false);
                 m_Player.transform.FindChild("Body1").gameObject.SetActive(false);
                 m_Player.transform.FindChild("Body2").gameObject.SetActive(false);
                break;

            case PlayerChartacter.hipster:              
                 m_Player.transform.FindChild("Body0").gameObject.SetActive(false);
                 m_Player.transform.FindChild("Body1").gameObject.SetActive(true);
                 m_Player.transform.FindChild("Body2").gameObject.SetActive(false);
                break;

            case PlayerChartacter.granny:
                 m_Player.transform.FindChild("Body0").gameObject.SetActive(false);
                 m_Player.transform.FindChild("Body1").gameObject.SetActive(false);
                 m_Player.transform.FindChild("Body2").gameObject.SetActive(true);
                break;
        }
                   
    }
}
