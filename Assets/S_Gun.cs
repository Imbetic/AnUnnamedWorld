using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Gun : MonoBehaviour
{
    public float m_reach, m_firerate, m_damage, m_accuracy, m_recoil, m_speed;
    public GameObject m_bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Fire()
    {
        GameObject bullet = Instantiate<GameObject>(m_bullet);
        bullet.GetComponent<S_Projectile>().Initialize(transform.position, transform.parent.rotation, m_damage, m_speed, m_reach);
        return bullet;
    }
}
