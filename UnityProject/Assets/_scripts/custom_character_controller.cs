using UnityEngine;
using System.Collections;

public class custom_character_controller : MonoBehaviour
{
    public float m_speedModifier = 1;
    public GameObject m_player;

    private Vector2 m_movAxis;      //Movement axis
    private Vector2 m_playerDir;    //Player direction
    private Vector2 m_tempMovAxis;
    private player_script m_ps;
    private float m_RotationSpeed = 100.0f;
    private Vector3 temp_dir;

	void Start ()
    {
        if (m_player == null)
        {
            m_player = GameObject.FindGameObjectWithTag("Player");
        }

        m_ps = m_player.GetComponent<player_script>();
	}

    void FixedUpdate()
    {
        #region Player movement
        m_tempMovAxis = new Vector2(Input.GetAxis("Horizontal"),
                                    Input.GetAxis("Vertical"));

        if (m_ps.m_collides)
        {
            m_movAxis = Vector2.zero;
        }
        else
        {
            m_movAxis = m_tempMovAxis;
        }

        m_player.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * m_RotationSpeed);

        temp_dir = new Vector3(m_tempMovAxis.x, 0, m_tempMovAxis.y);
        m_player.rigidbody.AddForce(temp_dir*10);
        //m_player.transform.position = Vector4.Lerp(m_player.transform.position,m_player.transform.position + new Vector3(m_movAxis.x, 0, m_movAxis.y), Time.deltaTime*10);
        #endregion

        #region Camera movement
        this.transform.position = Vector4.Lerp(this.transform.position, m_player.transform.position, Time.deltaTime*100);
        #endregion

        #region Player actions
        if (Input.GetButtonDown("MainAction"))
        {
            Debug.Log("LMB");
        }
        if (Input.GetButtonDown("AltAction"))
        {
            Debug.Log("RMB");
        }
        #endregion
    }
}
