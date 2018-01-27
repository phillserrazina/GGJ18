using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour {

	// VARIABLES

	public GearScript connectingGear;
	public bool isPowered = false;
	public bool counted = false;

	// FUNCTIONS

	void Start () {
		
	}
	

	void Update () 
	{
		if(connectingGear.powered == true)
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;

			this.isPowered = true;
		}
		else
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.red;

			this.isPowered = false;
		}
	}
}
