﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LadderClimb : MonoBehaviour {

    public static LadderClimb ladder;

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
            Movement.playerMove.moveUp = true;

            // Audio plays when player climbs laddrr
            GetComponent<AudioSource>().Play();
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Movement.playerMove.moveUp = false;
        }
    }
}
