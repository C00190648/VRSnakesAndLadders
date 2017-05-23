using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit, 100))
        {
            Debug.Log(hit.transform.name);

            hit.transform.position = new Vector3(hit.transform.position.x - 1, hit.transform.position.y, hit.transform.position.z);

            if (hit.collider.tag == "obj")
            {
                Renderer rend = hit.collider.GetComponent<Renderer>();
                rend.material.color = Color.yellow;
            }



        }



        //    hit.renderer.material.color = Color.red;
    
	}

    void Wait(Renderer rend)
    {
        var originalColor = rend.material.color;
        rend.material.color = Color.yellow;
       // yield Wait(2) ;
        rend.material.color = originalColor;
    }



}
