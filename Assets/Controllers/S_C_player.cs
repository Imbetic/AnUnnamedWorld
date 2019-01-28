using UnityEngine;
using System.Collections;

public class S_C_player : S_Controller
{
    public KeyCode up = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode down = KeyCode.S;
    public KeyCode right = KeyCode.D;
    
    public KeyCode dash = KeyCode.Space;
    
    public KeyCode ability1 = KeyCode.Alpha1;
    public KeyCode ability2 = KeyCode.Alpha2;
    public KeyCode ability3 = KeyCode.Alpha3;

    public Camera visioncam;
    public Camera cam;
    public GameObject vision;

    private void Start()
    {
        
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameObject[] obstructions = GameObject.FindGameObjectsWithTag("Obstruction");

            for (int i = 0; i < obstructions.Length; i++)
            {
                obstructions[i].GetComponent<S_Obstructor>().iInitialize(transform); ;
            }

            vision.SetActive(true);
            cam.enabled = true;
            visioncam.enabled = true;
        };
    }

    public override void SetCommands(int player)
    {
        //HÄR
        if (!isLocalPlayer)
        {
            return;
        };

        /*m_forward = Input.GetKey(up);
        m_backward = Input.GetKey(down);
        m_right = Input.GetKey(right);
        m_left = Input.GetKey(left);*/


        if (Input.GetKey(up))
        {
            if (Input.GetKey(down))
            {
                m_forward = false;
                m_backward = false;
            }
            else
            {
                m_forward = true;
                m_backward = false;
            }
        }
        else if (Input.GetKey(down))
        {
            m_forward = false;
            m_backward = true;
        }
        else
        {
            m_forward = false;
            m_backward = false;
        }

        if (Input.GetKey(right))
        {
            if (Input.GetKey(left))
            {
                m_left = false;
                m_right = false;
            }
            else
            {
                m_left = false;
                m_right = true;
            }
        }
        else if (Input.GetKey(left))
        {
            m_left = true;
            m_right = false;
        }
        else
        {
            m_left = false;
            m_right = false;
        }

        m_mousex = Input.GetAxis("Mouse X");
        m_mousey = Input.GetAxis("Mouse Y");

        m_dash = Input.GetKey(dash);
        m_attack = Input.GetMouseButton(0);
        m_defend = Input.GetMouseButton(1);

        //m_abilities[0] = Input.GetKey(ability1);
        //m_abilities[1] = Input.GetKey(ability2);
        //m_abilities[2] = Input.GetKey(ability3);

    }

}
