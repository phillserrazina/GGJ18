using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// VARIABLES

	public float powerOffCounter = 1;

	public enum GameStates
	{
		WALK,
		GEARS,
	}

	public GameStates currentState;

	private PlayerScript player;

	private GearManager gearManager;

	// FUNCTIONS

	void Start () 
	{
		currentState = GameStates.WALK;

		player = GameObject.Find ("Player").GetComponent<PlayerScript> ();
		gearManager = GameObject.FindObjectOfType<GearManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.FindObjectOfType<TransmiterScript>().satisfactionMeter <= 0)
		{
			SceneManager.LoadScene ("LoseScene");
		}

		switch(currentState)
		{
		case(GameStates.WALK):

			player.canMove = true;

			break;
		
		case(GameStates.GEARS):

			player.canMove = false;

			if(Input.GetKey(KeyCode.X))
			{
				currentState = GameStates.WALK;
			}

			break;
		}

		if(Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene ("MenuScene");
		}
	}

	public IEnumerator PowerOff()
	{
		float waitingTime = Random.Range (5.0f, 20.0f);

		yield return new WaitForSeconds (waitingTime);

		for(int i = 0; i < gearManager.gearArray.Length; i++)
		{
			if (Random.value < 0.5f)
				gearManager.gearArray [i].gearValues = 0f;
			else if (Random.value == 0.5f)
				gearManager.gearArray [i].gearValues = 45f;
			else
				gearManager.gearArray [i].gearValues = 225f;
		}

		powerOffCounter += 0.5f;

		GameObject.FindObjectOfType<RadioScript> ().powerOn = false;
	}
}
