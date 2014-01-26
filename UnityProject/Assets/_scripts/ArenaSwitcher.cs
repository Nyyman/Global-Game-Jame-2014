using UnityEngine;
using System.Collections;

public class ArenaSwitcher : MonoBehaviour
{
    public GameObject ArenaFloor;
    public GameObject ArenaBorders;
    public Material[] floorMaterials;
    public Material[] wallMaterials;
    public GameObject manager;

	// Use this for initialization
	void Start ()
    {
        manager = GameObject.Find("Manager");
        if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.baby)
        {
            ArenaFloor.renderer.material = floorMaterials[0];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.hipster)
        {
            ArenaFloor.renderer.material = floorMaterials[1];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.granny)
        {
            ArenaFloor.renderer.material = floorMaterials[2];
        }
        if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.baby)
        {
            ArenaBorders.renderer.material = wallMaterials[0];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.hipster)
        {
            ArenaBorders.renderer.material = wallMaterials[1];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.granny)
        {
            ArenaBorders.renderer.material = wallMaterials[2];
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.baby)
        {
            ArenaFloor.renderer.material = floorMaterials[0];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.hipster)
        {
            ArenaFloor.renderer.material = floorMaterials[1];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.granny)
        {
            ArenaFloor.renderer.material = floorMaterials[2];
        }
        if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.baby)
        {
            ArenaBorders.renderer.material = wallMaterials[0];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.hipster)
        {
            ArenaBorders.renderer.material = wallMaterials[1];
        }
        else if (CharacterChanger.instance.m_PlayerCharacter1 == PlayerChartacter.granny)
        {
            ArenaBorders.renderer.material = wallMaterials[2];
        }
	}
}
