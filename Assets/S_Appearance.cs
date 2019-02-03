using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class S_Appearance : MonoBehaviour
{
    public Sprite Idle;
    public Sprite InCombat;
    public Sprite ChargeRight1;
    public Sprite AttackRight1;
    public SpriteRenderer m_SpriteRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame




    public void Attacking()
    {
        m_SpriteRenderer.sprite = AttackRight1;

    }


    public void Preparing()
    {
        m_SpriteRenderer.sprite = ChargeRight1;

    }


    public void Sheathed()
    {
        m_SpriteRenderer.sprite = InCombat;

    }
}
