using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class S_Projectile : NetworkBehaviour
{
    public float m_damage, m_speed, m_reach;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(Vector3 p_position, Quaternion p_rotation, float p_damage, float p_speed, float p_reach)
    {
        transform.position = p_position;
        transform.rotation = p_rotation;
        m_damage = p_damage;
        m_reach = p_reach;
        GetComponent<Rigidbody2D>().AddForce(transform.up*p_speed, ForceMode2D.Impulse);      
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            if (m_reach < 0)
            {
                NetworkServer.Destroy(gameObject);
                m_reach -= Time.deltaTime;
            }
            else
                m_reach -= Time.deltaTime;
        }

    }
}
