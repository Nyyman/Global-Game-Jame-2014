using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour 
{
    public static PlayerSpawner instance;
    public int m_PlayerAmount = 2;
    public GameObject m_Player1Prefab;
    public GameObject m_Player2Prefab;
    public Vector3 m_Player1StartLoc;
    public Vector3 m_Player2StartLoc;
    private GameObject m_GUI;
    public bool m_PlayersSpawned = false;    

    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
        
        m_Player1StartLoc = new Vector3(-5, 0, 0);
        m_Player1StartLoc = new Vector3(5, 0, 0);        
	}

	void Update () 
    {
        if (!m_PlayersSpawned && Application.loadedLevel == 1)
        {
            m_GUI = GameObject.Find("GUI");
            CreatePlayers(m_PlayerAmount);
            m_PlayersSpawned = true;
        }
	}

    void CreatePlayers(int amount)
    {
        switch (amount)
        {
            case 1:
                ObjectPool.instance.Instantiate(m_Player1Prefab, m_Player1StartLoc, new Quaternion(0, 0, 0, 0));
                m_GUI.transform.Find("Health2").gameObject.SetActive(false);
                m_GUI.transform.Find("Score2").gameObject.SetActive(false);
                break;

            case 2:
                ObjectPool.instance.Instantiate(m_Player1Prefab, m_Player1StartLoc, new Quaternion(0, 0, 0, 0));
                ObjectPool.instance.Instantiate(m_Player2Prefab, m_Player2StartLoc, new Quaternion(0, 0, 0, 0));
                break;
        }
    }
}
