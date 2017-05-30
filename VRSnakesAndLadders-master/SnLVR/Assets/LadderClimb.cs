using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LadderClimb : MonoBehaviour {

    public static LadderClimb ladder;
    public bool canUse;

	// Use this for initialization
	void Start ()
    {
        gameObject.SetActive(false);
        ladder = this;

    }

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Movement>().moveUp = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Movement>().moveUp = true;
        }
    }
}
