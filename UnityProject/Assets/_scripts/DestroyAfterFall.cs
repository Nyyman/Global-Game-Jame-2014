using UnityEngine;
using System.Collections;

public class DestroyAfterFall : MonoBehaviour 
{
	void Update () 
    {
        if (transform.position.y < -1.0)
            ObjectPool.instance.Destroy(this.gameObject);
	}
}
