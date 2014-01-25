using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour 
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
