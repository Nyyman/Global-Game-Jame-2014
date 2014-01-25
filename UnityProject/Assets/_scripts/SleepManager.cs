//using UnityEngine;
//using System;
//using System.Collections;
//using System.Collections.Generic;

//[System.Serializable]
//public class AIsettings
//{
//    //public List<GameObject> AIs = new List<GameObject>();
//    public GameObject[] AIs;
//    public float sleepDistance = 10;
//    public float checkIntervals = 3;
//}

//[System.Serializable]
//public class DynamicObjectSettings
//{
//    public GameObject[] dynamicObjects;
//    public float sleepSpeed = 0.01f;
//    public float checkIntervals = 0.1f;
//}

//public class SleepManager : MonoBehaviour
//{
//    public AIsettings aiSettings;
//    public DynamicObjectSettings dSettings;
//    private Transform player;

//    // Use this for initialization
//    void Start()
//    {
//        player = GameObject.FindWithTag("Player").transform;
//        aiSettings.AIs = GameObject.FindGameObjectsWithTag("AI");
//        dSettings.dynamicObjects = GameObject.FindGameObjectsWithTag("Dynamic");

//        if (aiSettings.AIs.Length > 0)
//        {
//            StartCoroutine("CheckAIs");
//        }

//        if (dSettings.dynamicObjects.Length > 0)
//        {
//            StartCoroutine("CheckDynamicObjects");
//        }
//    }

//    IEnumerator CheckAIs()
//    {
//        for (int i = 0; i < aiSettings.AIs.Length; ++i)
//        {
//            yield return new WaitForSeconds(aiSettings.checkIntervals);

//            if (aiSettings.AIs[i].gameObject.activeSelf)
//            {
//                Debug.Log(!aiSettings.AIs[i].GetComponentsInChildren<Renderer>(true)[0].isVisible
//                    + " "
//                    + Vector3.Distance(aiSettings.AIs[i].transform.position, player.position)
//                    + " > "
//                    + aiSettings.sleepDistance);

//                if (aiSettings.AIs[i].gameObject.activeSelf)
//                {

//                    if (!aiSettings.AIs[i].GetComponentInChildren<Renderer>().isVisible
//                        && Vector3.Distance(aiSettings.AIs[i].transform.position, player.position)
//                        > aiSettings.sleepDistance)
//                    {
//                        Debug.Log("AI sleeping");
//                        aiSettings.AIs[i].gameObject.SetActive(false);
//                    }
//                }

//                else if (Vector3.Distance(aiSettings.AIs[i].transform.position, player.position) < aiSettings.sleepDistance)
//                {
//                    Debug.Log("AI awake");
//                    aiSettings.AIs[i].SetActive(true);
//                }
//            }

//            StartCoroutine("CheckAIs");
//        }
//    }

//    IEnumerator CheckDynamicObjects()
//    {
//        for (int i = 0; i < dSettings.dynamicObjects.Length; ++i)
//        {
//            yield return new WaitForSeconds(dSettings.checkIntervals);

//            if (dSettings.dynamicObjects[i].rigidbody.IsSleeping())
//            {
//                break;
//            }

//            if (dSettings.dynamicObjects[i].rigidbody.velocity.sqrMagnitude <
//                dSettings.sleepSpeed * dSettings.sleepSpeed)
//            {
//                Debug.Log("dynamic object is sleeping");
//                dSettings.dynamicObjects[i].rigidbody.Sleep();
//            }
//        }

//        StartCoroutine("CheckDynamicObjects");
//    }
//}
