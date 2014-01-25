using UnityEngine;
using System.Collections;

public class DUMMYDELELTEME : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Joystick1Button7))
        Debug.Log("1start");
        if (Input.GetKey(KeyCode.Joystick2Button7))
            Debug.Log("2start");
	}
}
