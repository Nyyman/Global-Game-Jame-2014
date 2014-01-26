using UnityEngine;
using System.Collections;

public class ArenaSwitcher : MonoBehaviour
{
    public GameObject ArenaFloor;
    public GameObject ArenaBorders;
    public Material[] floorMaterials;
    public Material[] wallMaterials;
    public GameObject manager;
    public GameObject babyProps;
    public GameObject hipsterProps;
    public GameObject grannyProps;

	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("Manager");
        if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.baby)
        {
            ArenaFloor.renderer.material = floorMaterials[0];
            ArenaBorders.renderer.material = wallMaterials[0];
            babyProps.SetActive(true);
            hipsterProps.SetActive(false);
            grannyProps.SetActive(false);
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.hipster)
        {
            ArenaFloor.renderer.material = floorMaterials[1];
            ArenaBorders.renderer.material = wallMaterials[1];
            babyProps.SetActive(false);
            hipsterProps.SetActive(true);
            grannyProps.SetActive(false);
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.granny)
        {
            ArenaFloor.renderer.material = floorMaterials[2];
            ArenaBorders.renderer.material = wallMaterials[2];
            babyProps.SetActive(false);
            hipsterProps.SetActive(false);
            grannyProps.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.baby)
        {
            ArenaFloor.renderer.material = floorMaterials[0];
            ArenaBorders.renderer.material = wallMaterials[0];
            babyProps.SetActive(true);
            hipsterProps.SetActive(false);
            grannyProps.SetActive(false);
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.hipster)
        {
            ArenaFloor.renderer.material = floorMaterials[1];
            ArenaBorders.renderer.material = wallMaterials[1];
            babyProps.SetActive(false);
            hipsterProps.SetActive(true);
            grannyProps.SetActive(false);
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.granny)
        {
            ArenaFloor.renderer.material = floorMaterials[2];
            ArenaBorders.renderer.material = wallMaterials[2];
            babyProps.SetActive(false);
            hipsterProps.SetActive(false);
            grannyProps.SetActive(true);
        }
	}
}
