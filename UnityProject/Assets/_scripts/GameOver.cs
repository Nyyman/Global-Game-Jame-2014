using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
    private float m_TimeScale;
    private bool IsGameOver = false;
    private GameObject m_GameOverScreen;

	void Start () 
    {
        m_GameOverScreen = transform.FindChild("GameOverScreen").gameObject;
	}	

	void Update () 
    {
        if (IsGameOver)
        {
            if (Input.anyKeyDown)
            {
                GoToMainMenu();
            }
        }       
	}

    public void Activate()
    {
        //IsGameOver = true;
        //m_GameOverScreen.SetActive(true);
        //m_GameOverScreen.transform.FindChild("Score1").FindChild("Amount").GetComponent<GUIText>().text = FindObjectOfType<ScoreScript2>().m_Score.ToString();
        //m_GameOverScreen.transform.FindChild("Score2").FindChild("Amount").GetComponent<GUIText>().text = FindObjectOfType<ScoreScript2>().m_Score.ToString();
        //PauseGame();
    }

    void GoToMainMenu()
    {
        UnPause();
        Destroy(GameObject.Find("GUI"));
        m_GameOverScreen.SetActive(false);
        Application.LoadLevel(0);
    }

    void PauseGame()
    {
        m_TimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    void UnPause()
    {
        Time.timeScale = m_TimeScale;
    }
}
