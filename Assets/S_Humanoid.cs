using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class S_Humanoid : S_BasePawn
{
    //Mind
    public float m_awareness; //vision, hearing
    public float m_intellect; //ability complexity

    public Rigidbody2D m_physics;
    //Skills - attack speed, recovery, damage, armor penetration, charge

    public float m_skill;

    float m_preparing = 0;
    float m_attackduration = 0;
    float m_attackdelay = 0;

    public S_Appearance Appearance;

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
        if (isLocalPlayer)
        {
            controller.CmdSetCommands(0); 
        }
        if (isLocalPlayer)
        {
            HeadRotation();
            BodyRotation();
            Combat();
        }
        
    }


    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Movement();
            m_physics.AddForce(new Vector2(-5 * m_physics.velocity.x, -5 * m_physics.velocity.y));
        }
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


    void HeadRotation()
    {
        if (controller.m_mousex > 2) controller.m_mousex = 2;
        else if (controller.m_mousex < -2) controller.m_mousex = -2;
        Head.transform.eulerAngles += new Vector3(0, 0, -controller.m_mousex * (0.8f + (m_agility / 5)) * 70 * Time.deltaTime);
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


    void Combat()
    {
        if (m_attackduration > 0)
        {
            m_attackduration -= Time.deltaTime;
            if(m_attackduration<=0)
            {
                //Back to Sheethed
                //disable attack hitbox;
                CmdInCombat();
                
                
                
            }
        }
        else if(m_attackdelay > 0)
        {
            m_attackdelay -= Time.deltaTime;
            if(m_attackdelay < 0)
            {
                m_attackduration = 0.3f;
                CmdAttack();
                
            }
        }
        else
        {
            if (controller.m_attack)
            {
                if(m_preparing == 0)
                {
                    CmdCharge();
                    
                }
                m_preparing += Time.deltaTime;
            }
            else
            {
                if (m_preparing>0)
                {
                    m_preparing = 0;
                    m_attackdelay = 0.15f;
                   
                }
            }
        }
    }

    [Command]
    void CmdAttack()
    {
        RpcAttack();
    }
    [Command]
    void CmdCharge()
    {
        RpcCharge();
    }
    [Command]
    void CmdInCombat()
    {
        RpcInCombat();
    }
    [ClientRpc]
    void RpcAttack()
    {
        Appearance.Attacking();
    }
    [ClientRpc]
    void RpcCharge()
    {
        Appearance.Preparing();
    }
    [ClientRpc]
    void RpcInCombat()
    {
        Appearance.Sheathed();
    }
}
