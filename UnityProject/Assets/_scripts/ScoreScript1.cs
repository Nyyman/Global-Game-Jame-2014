using UnityEngine;
using System.Collections;

public class ScoreScript1 : MonoBehaviour 
{
    public static ScoreScript1 instance;
    private GameObject m_GUI;
    public int m_Score;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () 
    {
        m_GUI = GameObject.Find("GUI");
        m_Score = 0;
        UpdateUI();  
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void AddPoints(int points)
    {
        m_Score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        string text = m_Score.ToString();
        m_GUI.transform.FindChild("Score1").GetComponent<GUIText>().text = text;
    }
}
