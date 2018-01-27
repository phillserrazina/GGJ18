using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// VARIABLES

	public enum GameStates
	{
		WALK,
		GEARS
	}

	public GameStates currentState;

	private PlayerScript player;

	// FUNCTIONS

	void Start () 
	{
		currentState = GameStates.WALK;

		player = GameObject.Find ("Player").GetComponent<PlayerScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(currentState)
		{
		case(GameStates.WALK):

			player.canMove = true;

			if(Input.GetKey(KeyCode.Z))
			{
				currentState = GameStates.GEARS;
			}

			break;
		
		case(GameStates.GEARS):

			player.canMove = false;

			if(Input.GetKey(KeyCode.X))
			{
				currentState = GameStates.WALK;
			}

			break;
		}
	}
}
