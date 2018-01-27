using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// VARIABLES

	[SerializeField] private float speed = 12.0f;
	private float gearIncrement = 22.5f;

	public bool canMove = true;
	private bool isPressing = false;

	private Rigidbody rb;
	private GearScript gear;
	private GearManager gearManager;
	private GameManager gameManager;

	// FUNCTIONS

	// Use this for initialization
	void Start () 
	{
		rb = gameObject.GetComponent<Rigidbody> ();
		// gear = GameObject.FindObjectOfType<GearScript> ();
		gameManager = GameObject.FindObjectOfType<GameManager> ();
		gearManager = GameObject.FindObjectOfType<GearManager> ();
	}


	void FixedUpdate () 
	{
		gear = gearManager.gearArray [gearManager.currentGear];

		// Regular Movement System
		if (canMove == true) 
		{
			float horizontalMovement = Input.GetAxisRaw ("Horizontal");

			rb.velocity = new Vector3 (horizontalMovement * speed, 0, 0);
		}

		// Gear Turning System
		if(gameManager.currentState == GameManager.GameStates.GEARS)
		{
			// Select Gear

			if(Input.GetKey(KeyCode.DownArrow))
			{
				if(isPressing == false)
				{
					gearManager.currentGear += 1;
				}

				isPressing = true;
			}

			if(Input.GetKeyUp(KeyCode.DownArrow))
			{
				isPressing = false;
			}

			if(Input.GetKey(KeyCode.UpArrow))
			{
				if(isPressing == false)
				{
					gearManager.currentGear -= 1;
				}

				isPressing = true;
			}

			if(Input.GetKeyUp(KeyCode.UpArrow))
			{
				isPressing = false;
			}

			// Turn Gear Right
			if (gear.snapped == false) 
			{
				// Check Input
				if (Input.GetKey (KeyCode.RightArrow)) 
				{
					// Guarantee that it is only pressed once
					if (isPressing == false) 
					{
						gear.gearValues += gearIncrement;

						// Is this the first gear?
						if (gear.tag == "First Gear") 
						{
							// If both gears are ready to snap, snap them
							if (gear.readyToSnap == true && gearManager.gearArray [gearManager.currentGear + 1].readyToSnap == true) 
							{
								gear.snapped = true;
								gearManager.gearArray [gearManager.currentGear + 1].snapped = true;

								Debug.Log (gear.name + " and " + gearManager.gearArray [gearManager.currentGear + 1].name + " snapped!");
							}
						}

						// Is this the last gear?
						else if (gear.tag == "Last Gear") 
						{
							// If both gears are ready to snap, snap them
							if (gear.readyToSnap == true && gearManager.gearArray [gearManager.currentGear - 1].readyToSnap == true) 
							{
								gear.snapped = true;
								gearManager.gearArray [gearManager.currentGear - 1].snapped = true;

								Debug.Log (gear.name + " and " + gearManager.gearArray [gearManager.currentGear - 1].name + " snapped!");
							}
						}

						// Is this one of the middle gears?
						else
						{
							// If all the gears are ready to snap, snap them
							if (gear.readyToSnap == true && 
								gearManager.gearArray [gearManager.currentGear + 1].readyToSnap == true && 
								gearManager.gearArray [gearManager.currentGear - 1].readyToSnap == true) 
							{
								gear.snapped = true;
								gearManager.gearArray [gearManager.currentGear + 1].snapped = true;
								gearManager.gearArray [gearManager.currentGear - 1].snapped = true;

								Debug.Log (gear.name + " and " + gearManager.gearArray [gearManager.currentGear + 1].name + " snapped!");
							}
						}
					}

					isPressing = true;
				}

				if (Input.GetKeyUp (KeyCode.RightArrow)) {
					isPressing = false;
				}

				// Turn Gear Left
				if (Input.GetKey (KeyCode.LeftArrow)) 
				{
					// Guarantee that it is only pressed once
					if (isPressing == false) 
					{
						gear.gearValues -= gearIncrement;

						// Is this the first gear?
						if (gear.tag == "First Gear") 
						{
							// If both gears are ready to snap, snap them
							if (gear.readyToSnap == true && gearManager.gearArray [gearManager.currentGear + 1].readyToSnap == true) 
							{
								gear.snapped = true;
								gearManager.gearArray [gearManager.currentGear + 1].snapped = true;

								Debug.Log (gear.name + " and " + gearManager.gearArray [gearManager.currentGear + 1].name + " snapped!");
							}
						}

						// Is this the last gear?
						else if (gear.tag == "Last Gear")  
						{
							// If both gears are ready to snap, snap them
							if (gear.readyToSnap == true && gearManager.gearArray [gearManager.currentGear - 1].readyToSnap == true) 
							{
								gear.snapped = true;
								gearManager.gearArray [gearManager.currentGear - 1].snapped = true;

								Debug.Log (gear.name + " and " + gearManager.gearArray [gearManager.currentGear - 1].name + " snapped!");
							}
						}

						// Is this one of the middle gears?
						else
						{
							// If all the gears are ready to snap, snap them
							if (gear.readyToSnap == true && 
								gearManager.gearArray [gearManager.currentGear + 1].readyToSnap == true && 
								gearManager.gearArray [gearManager.currentGear - 1].readyToSnap == true) 
							{
								gear.snapped = true;
								gearManager.gearArray [gearManager.currentGear + 1].snapped = true;
								gearManager.gearArray [gearManager.currentGear - 1].snapped = true;

								Debug.Log (gear.name + " and " + gearManager.gearArray [gearManager.currentGear + 1].name + " snapped!");
							}
						}
					}

					isPressing = true;
				}

				if (Input.GetKeyUp (KeyCode.LeftArrow)) {
					isPressing = false;
				}
			}
		}	
	}
}
