using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    private GameObject m_Player1;
    private GameObject m_Player2;
	
	void Start ()
    {
        GetPlayers();
	}	

	void Update () 
    {
        if (PlayerSpawner.instance.m_PlayersSpawned)
        {
            if (m_Player1 == null)
            {
                GetPlayers();
            }

            if (m_Player2 == null)
            {
                this.transform.position = Vector4.Lerp(this.transform.position, m_Player1.transform.position, Time.deltaTime * 100);
            }

            else
            {
                Vector3 player1 = m_Player1.transform.position;
                Vector3 player2 = m_Player2.transform.position;
                Vector3 target = (player1 + player2) / 2;
                this.transform.position = Vector4.Lerp(this.transform.position, target, Time.deltaTime * 100);
            }
        }
	}

    void GetPlayers()
    {
        m_Player1 = GameObject.Find("Player1");
        m_Player2 = GameObject.Find("Player2");
    }
}
