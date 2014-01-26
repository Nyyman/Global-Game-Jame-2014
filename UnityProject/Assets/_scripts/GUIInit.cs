using UnityEngine;
using System.Collections;

public class GUIInit : MonoBehaviour
{  
    private float m_time; //time from press
    GameObject m_GUI_base;
    GameObject m_Managers;

    void Start()
    {
        m_Managers = GameObject.Find("Managers");
        m_GUI_base = GameObject.Find("GUI").transform.FindChild("GUI_base").gameObject;
    }

    void OnMouseOver()
    {
        Debug.Log(this.name);
        m_time += Time.deltaTime;
        if (Input.GetMouseButton(0) && m_time >= 0.5f)
        {
            if (this.name == "GUI_less" || Input.GetAxis("Horizontal") < 0)
            {
                m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount--;
                CheckLimit();
                UpdateBase();
                m_time = 0;                
            }

            if (this.name == "GUI_more")
            {
                m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount++;
                CheckLimit();
                UpdateBase();
                m_time = 0;                
            }

            if (this.name == "GUI_start")
            {
                Application.LoadLevel(1);
            }

            if (this.name == "GUI_exit")
            {
                Application.Quit();
            }
        }
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount--;
            CheckLimit();
            UpdateBase();
            m_time = 0;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount++;
            CheckLimit();
            UpdateBase();
            m_time = 0;
        }

        if (Input.GetKey(KeyCode.Joystick1Button7))
        {
            Application.LoadLevel(1);
        }
    }

    void CheckLimit()
    {
        if (m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount < 1)
        {
            m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount = 1;
        }

        if (m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount > 2)
        {
            m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount = 2;
        }
    }

    void UpdateBase()
    {
        switch (m_Managers.GetComponent<PlayerSpawner>().m_PlayerAmount)
        {
            case 1:               
                m_GUI_base.renderer.material = m_GUI_base.GetComponent<MaterialContainer>().m_Material1;
                break;

            case 2:
                m_GUI_base.renderer.material = m_GUI_base.GetComponent<MaterialContainer>().m_Material2;
                break;
        }
    }
}
