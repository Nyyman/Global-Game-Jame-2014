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
    GameObject m_Player;

	void Start () 
    {
        m_Player = GameObject.Find("Player");
	}
	
    void SetCharacter(PlayerChartacter type)
    {
        switch (type)
        {
            case PlayerChartacter.baby:
                //m_Player.transform.FindChild("Body").GetComponent<MeshFilter>().mesh = 
                break;
            case PlayerChartacter.hipster:
                break;
            case PlayerChartacter.granny:
                break;
        }
    }
}
