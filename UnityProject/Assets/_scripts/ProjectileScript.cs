using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    public float m_Speed = 20.0f;
    public int m_Damage = 3;

    //private Vector3 hitPosition;
    //private bool goingToHit = false;
    private bool isMoving = true;
    
    private Vector3 direction;
    private Vector3 targetPosition;
    private Vector3 lastPosition;
    private int obstacleLayer;
    private Transform hitParent; 

    void Start()
    {      
        direction = transform.forward;
        targetPosition = transform.position;
        obstacleLayer = 1 << LayerMask.NameToLayer("Obstacle") |
        1 << LayerMask.NameToLayer("Enemy");
        
        ObjectPool.instance.Destroy(gameObject, 10);
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void OnSpawned()
    {
        direction = transform.forward;
        targetPosition = transform.position;
        obstacleLayer = 1 << LayerMask.NameToLayer("Player") |
        1 << LayerMask.NameToLayer("Enemy");     
        ObjectPool.instance.Destroy(gameObject, 30);
    }

    void Move()
    {        
        direction = transform.TransformDirection(Vector3.forward);
        targetPosition = transform.position + (direction * m_Speed);
        targetPosition = new Vector3(targetPosition.x, targetPosition.y + Physics.gravity.y * Time.deltaTime, targetPosition.z);

        //Ray ray = new Ray(transform.position, direction);
        Debug.DrawLine(transform.position, targetPosition, Color.red);

        //RaycastHit hitInfo;

        //if (Physics.Raycast(ray, out hitInfo, speed, obstacleLayer))
        //{
        //    goingToHit = true;
        //    hitPosition = hitInfo.point;
        //    hitParent = hitInfo.transform;
        //}
        
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);  
        lastPosition = transform.position;       

        //else
        //{
        //    float distance = Vector3.Distance(transform.position, hitPosition);

        //    if (distance <= 0)
        //    {
        //        isMoving = false;
        //        transform.parent = hitParent;
        //        //trail.enabled = false;

        //        if (hitParent != null)
        //        {
        //            if (hitParent.name != "Enemy")
        //            {
        //                hitParent.SendMessage("Use", transform.forward, SendMessageOptions.DontRequireReceiver);
        //            }

        //            else
        //            {
        //                hitParent.SendMessage("TakeDamage", transform.forward, SendMessageOptions.DontRequireReceiver);
        //            }
        //        }
        //    }

        //    else
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, hitPosition, speed * Time.deltaTime);
        //    }
        //}
    }

    void OnTriggerEnter(Collider col)
    {      
        if(col.GetComponent<Health>() != null)
        {           
            col.GetComponent<Health>().TakeDamage(m_Damage);           
            isMoving = false;
            rigidbody.isKinematic = true;
            transform.parent = col.transform;
        }
    }
}
