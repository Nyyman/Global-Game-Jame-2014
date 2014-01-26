using UnityEngine;
using System.Collections;

public class GUIHealth2 : MonoBehaviour
{
    public static GUIHealth2 instance;
    private GameObject m_GUI;
    private GameObject m_Player2; 

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        m_Player2 = GameObject.Find("Player2");
        m_GUI = GameObject.Find("GUI");

        if (PlayerSpawner.instance.m_PlayersSpawned)
        {
            UpdateUI();
        }
    }

    void Update()
    {           
    }

    public void UpdateUI()
    {
        if (m_Player2 == null)
        {
            m_Player2 = GameObject.Find("Player2");
        }

        string text = m_Player2.GetComponent<Health>().GetHealth().ToString();
        m_GUI.transform.FindChild("Health2").GetComponent<GUIText>().text = text;
    }
}
