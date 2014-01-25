﻿using UnityEngine;
using System.Collections;

public class ScoreScript2 : MonoBehaviour 
{
    public static ScoreScript2 instance;
    private GameObject m_GUI;
    private int m_Score;

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
        string text = "Score: " + m_Score.ToString();
        m_GUI.transform.FindChild("Score2").GetComponent<GUIText>().text = text;
    }
}