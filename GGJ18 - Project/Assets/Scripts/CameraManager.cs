using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	// VARIABLES

	public GameObject miniGame;

	private Vector3 offset;

	private PlayerScript player;

	private GameManager gameManager;

	// FUNCTIONS

	void Start()
	{
		offset = new Vector3 (0, 0, -10);

		gameManager = GameObject.FindObjectOfType<GameManager> ();
		player = GameObject.Find ("Player").GetComponent<PlayerScript> ();
	}

	void Update () 
	{
		if(gameManager.currentState == GameManager.GameStates.WALK)
			this.transform.position = player.transform.position + offset;

		else if (gameManager.currentState == GameManager.GameStates.GEARS)
		{
			this.transform.position = miniGame.transform.position + offset;
		}
	}
}
