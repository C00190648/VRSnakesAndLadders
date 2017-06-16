using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloor : MonoBehaviour {

    public static TrapFloor floor;
    bool moving;

	// Use this for initialization
	void Start () {
        moving = false;
        floor = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
            //GetComponent<Rigidbody>().AddForce(new Vector3(50, 0, 0) * Time.deltaTime);
            transform.position = transform.position + (new Vector3(1, 0, 0) * Time.deltaTime);
        }
	}

    public void setMoving(bool value) {
        moving = value;
    }
}
