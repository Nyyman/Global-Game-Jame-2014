using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    private GameObject m_Player;
	
	void Start ()
    {
        m_Player = GameObject.Find("Player");
	}	

	void Update () 
    {
        this.transform.position = Vector4.Lerp(this.transform.position, m_Player.transform.position, Time.deltaTime * 100);       
	}
}
