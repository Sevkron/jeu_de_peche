using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour {

    private enum ControlMode
    {
        Tank,
        Direct
    }

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_strafeSpeed = 1;
    [SerializeField] private float m_turnSpeed = 150;
    [SerializeField] private float m_jumpForce = 0;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Direct;

    private float m_currentV = 0;
    private float m_currentH = 0;
    private float m_currentV2 = 0;
    private float m_currentH2 = 0;
    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private Transform camera;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

    public GameObject m_Lantern;
    private float rotLampVertical;
    private bool maxLampUp, maxLampDown;
    public int combustibleNum = 2;
    public Text m_UICombustible;

    private float TorchMovementV;
    private float TorchMovementH;
    private float MinMaxRangeV;
    private float MinMaxRangeH;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider)) {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if(validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        } else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

	void Update () {
        TorchMovementV = 0;
        m_animator.SetBool("Grounded", m_isGrounded);

        switch(m_controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        m_wasGrounded = m_isGrounded;
    }

    private void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        float v2 = Input.GetAxis("Vertical2");
        float h2 = Input.GetAxis("Horizontal2");

        Transform camera = Camera.main.transform;
        //Transform camera = this.gameObject.transform;
        bool walk = Input.GetKey(KeyCode.LeftShift);

        //movement personnage
        if (v < 0) {
            if (walk) { v *= m_backwardsWalkScale; }
            else { v *= m_backwardRunScale; }
        } else if(walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);
        m_currentH2 = Mathf.Lerp(m_currentH2, h2, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        //Strafe Personnage
        transform.position += transform.right * m_currentH * m_strafeSpeed * Time.deltaTime;
        //Rotation Personnage
        transform.Rotate(0, m_currentH2 * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV + m_currentH);
        //JumpingAndLanding();
        UseCombustible();
        Light();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if(direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        UseCombustible();
        JumpingAndLanding();
        Light();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    public void UseCombustible()
    {
        if(Input.GetButtonDown("Consumable") && combustibleNum > 0)
        {
            m_Lantern.GetComponent<LanternScript>().AddLightIntensity();
            combustibleNum--;
            UpdateCombustibleNum();
        }
    }

    public void RechargeLamp()
    {
        if (Input.GetButtonDown("Consumable"))
        {
            m_Lantern.GetComponent<LanternScript>().AddFullLightIntensity();
        }
    }

    private void Light()
    {
        float verticalValue;
        float horizontalValue;

        verticalValue = -Input.GetAxisRaw("Vertical2") * Time.deltaTime;
        horizontalValue = -Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        RotLamp(verticalValue, horizontalValue);
    }

    private void RotLamp(float InputValueV, float InputValueH)
    {
        
        TorchMovementV += InputValueV * 50f;
        TorchMovementH += InputValueH * 50f;
        MinMaxRangeV -= TorchMovementV;
        MinMaxRangeH -= TorchMovementH;

        if (MinMaxRangeV < 35 && MinMaxRangeV > -35)
        {
            m_Lantern.transform.Rotate(new Vector3(0, TorchMovementV, 0)); // CHANGER CA SI CA TOURNE PAS CORRECTEMENT // METTRE DANS LA PREMIERE CASE PTDR
        }
        else
        {
            MinMaxRangeV += TorchMovementV;
        }

        if (MinMaxRangeH < 35 && MinMaxRangeH > -35)
        {
            m_Lantern.transform.Rotate(new Vector3(0, TorchMovementH, 0)); // CHANGER CA SI CA TOURNE PAS CORRECTEMENT // METTRE DANS LA PREMIERE CASE PTDR
        }
        else
        {
            MinMaxRangeH += TorchMovementH;
        }
    }

    public void UpdateCombustibleNum()
    {
        m_UICombustible.text = "" + combustibleNum;
    }
}