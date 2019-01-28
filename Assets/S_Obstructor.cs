using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class S_Obstructor : NetworkBehaviour {

    public Transform shadow;
    public Transform localplayer = null;
    public MeshFilter lowerMesh, upperMesh, rightMesh, leftMesh;

	// Use this for initialization
	void Start ()
    {

	}

    public void iInitialize(Transform p_localPlayer)
    {
        localplayer = p_localPlayer;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (localplayer == null)
        {

        }
        else
        {
            shadow.position = new Vector3(transform.position.x - (localplayer.position.x - transform.position.x) * (shadow.localScale.x - 1), transform.position.y - (localplayer.position.y - transform.position.y) * (shadow.localScale.y - 1), shadow.position.z);

            Vector3[] vertices = lowerMesh.mesh.vertices;
            vertices[1] = new Vector3(shadow.position.x - transform.position.x + (shadow.localScale.x / 2), shadow.position.y - transform.position.y - (shadow.localScale.y / 2), vertices[1].z);
            vertices[3] = new Vector3(shadow.position.x - transform.position.x - (shadow.localScale.x / 2), shadow.position.y - (shadow.localScale.y / 2) - transform.position.y, vertices[3].z);
            lowerMesh.mesh.vertices = vertices;

            vertices = upperMesh.mesh.vertices;
            vertices[0] = new Vector3(shadow.position.x - transform.position.x - (shadow.localScale.x / 2), shadow.position.y - transform.position.y + (shadow.localScale.y / 2), vertices[0].z);
            vertices[2] = new Vector3(shadow.position.x - transform.position.x + (shadow.localScale.x / 2), shadow.position.y - transform.position.y + (shadow.localScale.y / 2), vertices[2].z);
            upperMesh.mesh.vertices = vertices;

            vertices = leftMesh.mesh.vertices;
            vertices[1] = new Vector3(shadow.position.x - transform.position.x - (shadow.localScale.x / 2), shadow.position.y - transform.position.y + (shadow.localScale.y / 2), vertices[0].z);
            vertices[2] = new Vector3(shadow.position.x - transform.position.x - (shadow.localScale.x / 2), shadow.position.y - transform.position.y - (shadow.localScale.y / 2), vertices[2].z);
            leftMesh.mesh.vertices = vertices;

            vertices = rightMesh.mesh.vertices;
            vertices[3] = new Vector3(shadow.position.x - transform.position.x + (shadow.localScale.x / 2), shadow.position.y - transform.position.y + (shadow.localScale.y / 2), vertices[0].z);
            vertices[0] = new Vector3(shadow.position.x - transform.position.x + (shadow.localScale.x / 2), shadow.position.y - transform.position.y - (shadow.localScale.y / 2), vertices[2].z);
            rightMesh.mesh.vertices = vertices;
        }
        //lower.GetComponent<MeshFilter>().mesh.vertices[0] = new Vector3(1, 1, 1);
        //lower.GetComponent<MeshFilter>().mesh.vertices[0] = new Vector3(1, 1, 1);
        //lower.GetComponent<MeshFilter>().mesh.vertices[0] = new Vector3(1, 1, 1);
        
    }
}
