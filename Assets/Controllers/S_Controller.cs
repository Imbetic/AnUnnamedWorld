using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class S_Controller : NetworkBehaviour
{

    public bool m_forward;
    public bool m_backward;
    public bool m_left;
    public bool m_right;

    public float m_mousey;
    public float m_mousex;

    public bool m_dash;
    public bool m_attack;
    public bool m_defend;

    public bool[] m_abilities;

    private void Awake()
    {
        m_abilities = new bool[3];
    }

    public virtual void SetCommands(int player)
    {

    }

}
