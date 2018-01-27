using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour {

	// VARIABLES

	private int powerCounter = 0;

	public bool powerOn = false;

	private BatteryScript[] batteries;
	private GameManager gameManager;

	// FUNCTIONS
	void Start () 
	{
		batteries = GameObject.FindObjectsOfType<BatteryScript> ();
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < batteries.Length; i++)
		{
			if(batteries[i].isPowered == true)
			{
				if (batteries [i].counted == false) 
				{
					powerCounter++;
				}

				batteries [i].counted = true;
			}

			if(batteries[i].isPowered == false)
			{
				if (batteries [i].counted == true) 
				{
					powerCounter--;
				}

				batteries [i].counted = false;
			}
		}

		if (powerCounter == batteries.Length && powerOn == false)
		{
			powerOn = true;

			StartCoroutine (gameManager.PowerOff ());

			GameObject.Find ("PowerLight").GetComponent<Renderer> ().material.color = Color.green;
		}
		else if (powerCounter != batteries.Length)
		{
			powerOn = false;

			GameObject.Find ("PowerLight").GetComponent<Renderer> ().material.color = Color.red;
		}
	}
}
