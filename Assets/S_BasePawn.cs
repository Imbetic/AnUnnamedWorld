using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class S_BasePawn : MonoBehaviour {

    public S_Controller controller;

    //Defensive
    public float m_vitality; //Health, stamina
    public float m_determination; //pain meter, recovery

    //Offensive
    public float m_strength; //damage/armor penetration, item viability
    public float m_will; //charge rate

    //Supportive
    public float m_mobility; //movement speed
    public float m_agility; //turn speed, dash recovery

    public Transform Head;
    public Transform Body;

    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
