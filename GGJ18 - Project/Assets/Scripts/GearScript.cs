using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class GearScript : MonoBehaviour {

	// VARIABLES

	[Range(-359, 359)] public float gearValues = 90.0f;

	[SerializeField] private float correctRotX = 0.0f;
	private float currentGear = 0;

	public bool readyToSnap = false;
	public bool snapped = false;

	public GameObject gearGraphic;

	private GearManager gearManager;

	// FUNCTIONS


	void Start () 
	{
		gearManager = GameObject.FindObjectOfType<GearManager> ();
	}

	void Update () 
	{
		// Change gear color to green when selected and when in gears mode
		if (GameObject.FindObjectOfType<GameManager> ().currentState == GameManager.GameStates.GEARS) 
		{
			if (gameObject.name == gearManager.gearArray [gearManager.currentGear].name) 
			{
				gameObject.GetComponentInChildren<Renderer> ().material.color = Color.green;
			}

			if (gameObject.name != gearManager.gearArray [gearManager.currentGear].name) {
				
				gameObject.GetComponentInChildren<Renderer> ().material.color = Color.white;
			}
		}

		// Change gear color to white when in walk mode
		if (GameObject.FindObjectOfType<GameManager> ().currentState == GameManager.GameStates.WALK) 
		{
			gameObject.GetComponentInChildren<Renderer> ().material.color = Color.white;
		}


		if(gearValues >= 360 || gearValues <= -360)
		{
			gearValues = 0;
		}

		if (snapped == false) 
		{
			gearGraphic.transform.rotation = Quaternion.Euler (gearValues, 90.0f, 90.0f);
		}
			
		if(gearValues == correctRotX)
		{
			readyToSnap = true;

//			Debug.Log (this.name + " is ready to Snap!");
		}
	}
}
