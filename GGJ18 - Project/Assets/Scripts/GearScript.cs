using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class GearScript : MonoBehaviour {

	// VARIABLES

	[Range(0, 359)] public float gearValues = 90.0f;

	[SerializeField] private float correctRotX = 0.0f;
	private int gearNumber;

	public bool readyToSnap = false;
	public bool snapped = false;
	public bool powered = false;

	public GameObject gearGraphic;

	private GearManager gearManager;

	// FUNCTIONS


	void Start () 
	{
		gearManager = GameObject.FindObjectOfType<GearManager> ();

		for(int i = 0; i < gearManager.gearArray.Length; i++)
		{
			if(gameObject.name == gearManager.gearArray[i].name)
			{
				gearNumber = i;
			}
		}
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


		if(gearValues >= 360f)
		{
			gearValues = 0f;
		}
		else if (gearValues < 0f)
		{
			gearValues = 337.5f;
		}

		if (snapped == false) 
		{
			gearGraphic.transform.rotation = Quaternion.Euler (gearValues, 90.0f, 90.0f);
		}

		// Check if it is in right position
		if(gearValues == correctRotX)
		{
			// Is this the first gear?
			if (gameObject.tag == "First Gear") 
			{
				readyToSnap = true;

				powered = true;
			}

			// Is this the last gear?
			else if (gameObject.tag == "Last Gear") 
			{
				// If the second to last gear is in the right pos, trigger this
				if (gearManager.gearArray [gearNumber - 1].powered == true) 
				{
					powered = true;

					if (gearManager.gearArray [gearNumber - 1].readyToSnap == true) 
					{
						readyToSnap = true;
					}
				}
				else
				{
					powered = false;
				}
			}

			// Is this one of the middle gears?
			else if(gameObject.tag == "Middle Gear")
			{
				// If the gear before this one is powered, power this one
				if (gearManager.gearArray [gearNumber - 1].powered == true) 
				{
					powered = true;

					if(gearManager.gearArray [gearNumber + 1].readyToSnap == true && 
						gearManager.gearArray [gearNumber - 1].readyToSnap == true)
					{
						readyToSnap = true;
					}
				}
				else
				{
					powered = false;
				}
			}
		}

		if(gearValues != correctRotX)
		{
			// Is this the first gear?
			if (gameObject.tag == "First Gear") 
			{
				readyToSnap = false;

				powered = false;
			}

			// Is this the last gear?
			else if (gameObject.tag == "Last Gear") 
			{
				readyToSnap = false;

				powered = false;
			}

			// Is this one of the middle gears?
			else if(gameObject.tag == "Middle Gear")
			{
				readyToSnap = false;

				powered = false;
			}
		}

		// Is this the first gear?
		if (gameObject.tag == "First Gear") 
		{
			// If both gears are ready to snap, snap them
			if (readyToSnap == true && gearManager.gearArray [1].readyToSnap == true) 
			{
				snapped = true;
				gearManager.gearArray [gearManager.currentGear + 1].snapped = true;

				Debug.Log (gameObject.name + " and " + gearManager.gearArray [gearManager.currentGear + 1].name + " snapped!");
			}
		}

		// Is this the last gear?
		else if (gameObject.tag == "Last Gear") 
		{
			// If both gears are ready to snap, snap them
			if (readyToSnap == true && gearManager.gearArray [gearManager.gearArray.Length - 1].readyToSnap == true) 
			{
				snapped = true;
				gearManager.gearArray [gearManager.currentGear - 1].snapped = true;

				Debug.Log (gameObject.name + " and " + gearManager.gearArray [gearManager.currentGear - 1].name + " snapped!");
			}
		}

		// Is this one of the middle gears?
		else if(gameObject.tag == "Middle Gear")
		{
			// If all the gears are ready to snap, snap them
			if (readyToSnap == true && 
				gearManager.gearArray [gearNumber + 1].readyToSnap == true && 
				gearManager.gearArray [gearNumber - 1].readyToSnap == true) 
			{
				snapped = true;
				gearManager.gearArray [gearNumber + 1].snapped = true;
				gearManager.gearArray [gearNumber - 1].snapped = true;

				Debug.Log (gameObject.name + " and " + gearManager.gearArray [gearManager.currentGear + 1].name + " snapped!");
			}
		}
	}
}
