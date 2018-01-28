using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour {

	// VARIABLES

	private int powerCounter = 0;

	public bool powerOn = false;
	public float x;

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

			x = Random.value;

			StartCoroutine (gameManager.PowerOff ());

			GameObject.Find ("PowerLight").GetComponent<Renderer> ().material.color = Color.green;
			GameObject.Find ("PowerLight").GetComponent<Light> ().color = Color.green;

			GameObject.Find ("RoomLight").GetComponent<Light> ().intensity = 5f;
			GameObject.Find ("RoomLight2").GetComponent<Light> ().intensity = 5f;

			GameObject.Find ("WarningLight").GetComponent<Renderer> ().material.color = Color.green;
			GameObject.Find ("WarningLight").GetComponent<Light> ().color = Color.green;
		}
		else if (powerCounter != batteries.Length)
		{
			powerOn = false;

			GameObject.Find ("PowerLight").GetComponent<Renderer> ().material.color = Color.red;
			GameObject.Find ("PowerLight").GetComponent<Light> ().color = Color.red;

			GameObject.Find ("RoomLight").GetComponent<Light> ().intensity = 0f;
			GameObject.Find ("RoomLight2").GetComponent<Light> ().intensity = 0f;

			GameObject.Find ("WarningLight").GetComponent<Renderer> ().material.color = Color.red;
			GameObject.Find ("WarningLight").GetComponent<Light> ().color = Color.red;
		}
	}
}
