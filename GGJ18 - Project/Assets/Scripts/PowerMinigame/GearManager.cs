using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour {

	// VARIABLES

	public int currentGear = 0;

	public GearScript[] gearArray;

	// FUNCTIONS

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentGear = Mathf.Clamp (currentGear, 0, gearArray.Length - 1);
	}
}
