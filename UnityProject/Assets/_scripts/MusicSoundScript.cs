using UnityEngine;
using System.Collections;

public class MusicSoundScript : MonoBehaviour
{
    public GameObject m_player;
    //
    public AudioClip[] game_bgm;
    //Random sayings
    public AudioClip[] baby_line_sfx;
    public AudioClip[] hipster_line_sfx;
    public AudioClip[] granny_line_sfx;
    //
    public AudioClip[] selection_sfx;
    //Attacks
    public AudioClip baby_atck_sfx;
    public AudioClip hipster_melee_sfx;
    public AudioClip hipster_ranged_sfx;
    public AudioClip granny_melee_sfx;
    public AudioClip granny_ranged_sfx;
    //Taking damage
    public AudioClip baby_dmgd_sfx;
    public AudioClip hipster_dmgd_sfx;
    public AudioClip granny_dmgd_sfx;
    //Death
    public AudioClip baby_death_sfx;
    public AudioClip hipster_death_sfx;
    public AudioClip granny_death_sfx;

    private AudioSource m_as;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void PlaySFX(string text)
    {
        if (m_player == null)
        {
            m_player = GameObject.Find("Player1");
            m_as = m_player.GetComponent<AudioSource>();
        }

        switch (text)
        {
        case "Baby Death":
                m_as.PlayOneShot(baby_death_sfx);
                break;
        case "Hipster Death":
                m_as.PlayOneShot(hipster_death_sfx);
                break;
        case "Granny Death":
                m_as.PlayOneShot(granny_death_sfx);
                break;
        case "Baby Attack":
                m_as.PlayOneShot(baby_atck_sfx);
                break;
        case "Hipster Melee":
                m_as.PlayOneShot(hipster_melee_sfx);
                break;
        case "Hipster Ranged":
                m_as.PlayOneShot(hipster_ranged_sfx);
                break;
        case "Granny Ranged":
                m_as.PlayOneShot(granny_ranged_sfx);
                break;
        case "Baby Select":
                m_as.PlayOneShot(selection_sfx[0]);
                break;
        case "Hipster Select":
                m_as.PlayOneShot(selection_sfx[1]);
                break;
        case "Granny Select":
                m_as.PlayOneShot(selection_sfx[2]);
                break;
            default:
                break;
        }
    }
}
