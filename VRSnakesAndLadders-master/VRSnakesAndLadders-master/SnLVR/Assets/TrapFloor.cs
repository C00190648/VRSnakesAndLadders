using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloor : MonoBehaviour {

    public static TrapFloor floor;
    bool moving;
    float moveTimer;

	// Use this for initialization
	void Start () {
        moving = false;
        moveTimer = 0f;
        floor = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
            moveTimer += Time.deltaTime;
            if (moveTimer > 3)
            {
                transform.position = transform.position + (new Vector3(5, 0, 0) * Time.deltaTime);
            }
        }
	}

    public void setMoving(bool value) {
        moving = value;
    }
}
