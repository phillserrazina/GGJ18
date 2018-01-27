using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour {

	// VARIABLES

	public GearScript connectingGear;

	// FUNCTIONS

	void Start () {
		
	}
	

	void Update () 
	{
		if(connectingGear.powered == true)
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		}
		else
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}
