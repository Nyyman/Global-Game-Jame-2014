using UnityEngine;
using System.Collections;

public class GUIInit : MonoBehaviour
{
    public int playerCount = 1;
    private float m_time; //time from press

	void OnMouseOver()
    {
        m_time += Time.deltaTime;
        if (Input.GetMouseButton(0) && m_time >= 0.5f)
        {
            if(this.name == "GUI_less" && playerCount > 1)
            {
                Debug.Log("Decreased player count");
                playerCount--;
                m_time = 0;
            }
            if (this.name == "GUI_more" && playerCount < 3)
            {
                Debug.Log("Increased player count");
                playerCount++;
                m_time = 0;
            }
            if (this.name == "GUI_start" && playerCount < 3)
            {
                Application.LoadLevel(1);
            }
            if (this.name == "GUI_exit" && playerCount < 3)
            {
                Application.Quit();
            }
        }
	}
}
