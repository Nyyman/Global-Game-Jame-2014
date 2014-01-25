using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
    private PlayerMotor motor;

    //Camera settings
    private Quaternion startRotation;
    private float sensitivityX = 3.0f;
    private float minimumX = -360.0f;
    private float maxmumX = 360.0f;
    private float rotationX = 0.0f;

    private Quaternion startHeadRotation;
    private float sensitivityY = 7.0f;
    private float minimumY = -85.0f;
    private float maxmumY = 85.0f;
    private float rotationY = 0.0f;

    private GameObject m_Ground;
    Plane m_PlayerPlane = new Plane();
    Transform m_MarkerObject;
    
    //Layermask
    public LayerMask layerMask;

    //sprint 
    bool sprint = false;

    //Jump    
    private enum JumpState
    {
        can,
        isGoingTo,
        cant
    }

    JumpState jumpState = JumpState.cant;
    private float jumpStrength = 5.0f;
    private float sprintJumpStrength = 15.0f;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        startRotation = transform.localRotation;
        m_Ground = GameObject.Find("Ground");

        //if (!Screen.lockCursor)
        //{
        //    Screen.lockCursor = true;
        //}
    }

    void Update()
    {
        ButtonInput();
        MouseInput();        
        
        this.transform.position = Vector4.Lerp(this.transform.position, transform.position, Time.deltaTime * 100);
       
    }

    void FixedUpdate()
    {
        PhysicsInput();
    }

    void ButtonInput()
    {
        //if (Input.GetButton("Sprint"))
        //{
        //    sprint = true;
        //}

        //else
        //{
        //    sprint = false;
        //}

        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (jumpState == JumpState.can)
        //    {
        //        jumpState = JumpState.isGoingTo;
        //    }
        //}

        #region Player actions

        if (Input.GetButtonDown("MainAction"))
        {
            CharacterChanger.instance.SetCharacter(PlayerChartacter.hipster);
            Debug.Log("LMB");
        }

        if (Input.GetButtonDown("AltAction"))
        {
            Debug.Log("RMB");
        }

        #endregion
    }

    void MouseInput()
    {
        //rotationX = MouseRotate(rotationX, "Mouse X", sensitivityX, minimumX, maxmumX);
        //rotationY = MouseRotate(rotationY, "Mouse Y", sensitivityY, minimumY, maxmumY);
        //transform.localRotation = RotateTransform(rotationX, Vector3.up, startRotation);
        float speed = 4.0f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        m_PlayerPlane = new Plane(Vector3.up, transform.position);

        float rayDistance = 0.0f;
        if (m_PlayerPlane.Raycast(ray, out rayDistance))
        {
            var targetPoint = ray.GetPoint(rayDistance);
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
           // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
      }

    float MouseRotate(float rotation, string axisName, float sensitivity, float minRotation, float maxRotation)
    {
        rotation += Input.GetAxis(axisName) * sensitivity;
        rotation = ClampAngle(rotation, minRotation, maxRotation);
        return rotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
        {
            angle += 360.0f;
        }

        else if (angle > 360.0f)
        {
            angle -= 360.0f;
        }

        return Mathf.Clamp(angle, min, max);
    }

    Quaternion RotateTransform(float rotation, Vector3 axis, Quaternion startRotation)
    {
        Quaternion newQuaternion = Quaternion.AngleAxis(rotation, axis);
        Quaternion result = startRotation * newQuaternion;
        return result;
    }

    void PhysicsInput()
    {
        Vector3 movement = new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical"));

        motor.Move(movement, sprint);

        if (jumpState == JumpState.isGoingTo)
        {
            if (!sprint)
            {
                motor.Jump(jumpStrength);
            }

            else
            {
                motor.Jump(sprintJumpStrength);
            }

            jumpState = JumpState.cant;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Ground")
        {
            jumpState = JumpState.can;
        }
    }   
}
