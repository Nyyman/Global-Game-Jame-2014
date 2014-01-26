using UnityEngine;
using System.Collections;

public class GUIHealth1 : MonoBehaviour
{
    public static GUIHealth1 instance;
    private GameObject m_GUI;
    private GameObject m_Player1; 

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        m_Player1 = GameObject.Find("Player1");
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
        if (m_Player1 == null)
        {
            m_Player1 = GameObject.Find("Player1");
        }

        string text = m_Player1.GetComponent<Health>().GetHealth().ToString();
        m_GUI.transform.FindChild("Health1").GetComponent<GUIText>().text = text;
    }
}
