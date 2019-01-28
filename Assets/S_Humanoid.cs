using UnityEngine;
using System.Collections;

public class S_Humanoid : S_BasePawn
{
    //Mind
    public float m_awareness; //vision, hearing
    public float m_intellect; //ability complexity

    public Rigidbody2D m_physics;
    //Skills - attack speed, recovery, damage, armor penetration, charge

    public float m_skill;

    /*public float m_staffskill;
    public float m_swordskill;
    public float m_hammerskill;
    public float m_ropedskill;
    public float m_fistskill;
 
    public float m_throwskill;
    public float m_bowskill;
    public float m_gunskill;*/
     

    // Use this for initialization
    void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        controller.SetCommands(0);
        if (controller.m_mousex > 2) controller.m_mousex = 2;
        else if (controller.m_mousex < -2) controller.m_mousex = -2;
        Head.transform.eulerAngles += new Vector3(0, 0, -controller.m_mousex * (0.8f+(m_agility/5)) * 70 * Time.deltaTime); 
        BodyRotation();
    }

    private void FixedUpdate()
    {
        Movement();
        //m_physics.velocity.Set(m_physics.velocity.x-(2*Mathf.Pow(m_physics.velocity.x, 2)), m_physics.velocity.y-(2*Mathf.Pow(m_physics.velocity.y, 2)));
        m_physics.AddForce(new Vector2(-5*m_physics.velocity.x, -5*m_physics.velocity.y));
    }

    void Movement()
    {
        if (controller.m_forward)
        {
            if (controller.m_left)
            {
                m_physics.AddForce(Head.transform.up * m_mobility * (1 / Mathf.Sqrt(2)));
                m_physics.AddForce(Head.transform.right * -m_mobility * (1 / Mathf.Sqrt(2)));
            }
            else if (controller.m_right)
            {
                m_physics.AddForce(Head.transform.up * m_mobility * (1 / Mathf.Sqrt(2)));
                m_physics.AddForce(Head.transform.right * m_mobility * (1 / Mathf.Sqrt(2)));
            }
            else
            {
                m_physics.AddForce(Head.transform.up * m_mobility);
            }
        }
        else if (controller.m_backward)
        {
            if (controller.m_left)
            {
                m_physics.AddForce(Head.transform.up * -m_mobility * (1 / Mathf.Sqrt(2)));
                m_physics.AddForce(Head.transform.right * -m_mobility * (1 / Mathf.Sqrt(2)));
            }
            else if (controller.m_right)
            {
                m_physics.AddForce(Head.transform.up * -m_mobility * (1 / Mathf.Sqrt(2)));
                m_physics.AddForce(Head.transform.right * m_mobility * (1 / Mathf.Sqrt(2)));
            }
            else
            {
                m_physics.AddForce(Head.transform.up * -m_mobility);
            }
        }
        else if (controller.m_left)
        {
            m_physics.AddForce(Head.transform.right * -m_mobility);
        }
        else if (controller.m_right)
        {
            m_physics.AddForce(Head.transform.right * m_mobility);
        }
    }

    void BodyRotation()
    {
        float angle1 = Body.transform.eulerAngles.z + 180;
        float angle2 = Head.transform.eulerAngles.z + 180;
        
        if(angle1 > angle2)
        {
            float leftdist = angle1 - angle2;
            float rightdist = 360 - leftdist;
            if(rightdist < leftdist)
            {
                Body.transform.eulerAngles += new Vector3(0, 0, Time.deltaTime* Mathf.Pow(rightdist, (1.5f + (m_agility / 20)) )/ 2);
            }
            else
            {
                Body.transform.eulerAngles -= new Vector3(0, 0, Time.deltaTime * Mathf.Pow(leftdist, (1.5f + (m_agility / 20)) )/ 2);
            }
        }
        else if(angle1 < angle2)
        {
            float rightdist = angle2 - angle1;
            float leftdist = 360 - rightdist;
            if (rightdist < leftdist)
            {
                Body.transform.eulerAngles += new Vector3(0, 0, Time.deltaTime * Mathf.Pow(rightdist, (1.5f + (m_agility / 20))) / 2);
            }
            else
            {
                Body.transform.eulerAngles -= new Vector3(0, 0, Time.deltaTime * Mathf.Pow(leftdist, (1.5f + (m_agility/20)))/ 2);
            }
        }



    }
}
