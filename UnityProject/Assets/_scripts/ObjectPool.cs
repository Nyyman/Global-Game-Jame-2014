using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject[] objectPrefabs;
    public int[] amountToBuffer;
    public List<GameObject>[] pooledObjects;
    public int defaultBufferAmount = 3;
    protected GameObject containerObject;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        containerObject = gameObject;
        pooledObjects = new List<GameObject>[objectPrefabs.Length];

        int i = 0;

        foreach (GameObject objectPrefab in objectPrefabs)
        {
            pooledObjects[i] = new List<GameObject>();
            int bufferAmount;

            if (i < amountToBuffer.Length)
            {
                bufferAmount = amountToBuffer[i];
            }

            else
            {
                bufferAmount = defaultBufferAmount;
            }

            for (int n = 0; n < bufferAmount; ++n)
            {
                GameObject newObj = Instantiate(objectPrefab) as GameObject;
                newObj.name = objectPrefab.name;
                Destroy(newObj);
            }

            ++i;
        }
    }

    public GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < objectPrefabs.Length; ++i)
        {
            GameObject pooledObject = objectPrefabs[i];

            if (pooledObject == prefab)
            {
                if (pooledObjects[i].Count > 0)
                {
                    pooledObject = pooledObjects[i][0];
                    pooledObjects[i].RemoveAt(0);
                    pooledObject.transform.parent = null;
                    pooledObject.transform.position = position;
                    pooledObject.transform.rotation = rotation;
                    pooledObject.SetActive(true);
                    pooledObject.SendMessage("OnSpawned", SendMessageOptions.DontRequireReceiver);
                    return pooledObject;
                }

                else
                {
                    pooledObject = GameObject.Instantiate(objectPrefabs[i], position, rotation) as GameObject;
                    pooledObject.name = objectPrefabs[i].name;
                    pooledObject.SendMessage("OnSpawned", SendMessageOptions.DontRequireReceiver);
                    return pooledObject;
                }                
            }
        }

        Debug.Log(prefab.name + " not found from ObjectPool", this);
        return null;
    }

    public void Destroy(GameObject obj)
    {
        for (int i = 0; i < objectPrefabs.Length; ++i)
        {
            if (objectPrefabs[i].name == obj.name)
            {
                obj.SetActive(false);
                obj.transform.parent = containerObject.transform;
                pooledObjects[i].Add(obj);
                return;
            }
        }

        Debug.Log("Could not return to pool " + obj.name, this);
    }

    public struct DestroyParameters
    {
        public GameObject obj;
        public float time;
    }

    public void Destroy(GameObject obj, float time)
    {
        DestroyParameters parameters = new DestroyParameters();
        parameters.obj = obj;
        parameters.time = time;
        StartCoroutine(WaitAndDestroy(parameters).GetEnumerator());
    }

    public IEnumerable WaitAndDestroy(DestroyParameters parameters)
    {
        yield return new WaitForSeconds(parameters.time);
        this.Destroy(parameters.obj);
    }
}
