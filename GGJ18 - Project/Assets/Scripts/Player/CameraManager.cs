using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	// VARIABLES

	public GameObject powerMiniGame;
	public GameObject transMiniGame;

	private Vector3 offset;

	private PlayerScript player;

	private GameManager gameManager;

	// FUNCTIONS

	void Start()
	{
		offset = new Vector3 (0, 2, -10);

		gameManager = GameObject.FindObjectOfType<GameManager> ();
		player = GameObject.Find ("Player").GetComponent<PlayerScript> ();
	}

	void Update () 
	{
		if(gameManager.currentState == GameManager.GameStates.WALK)
			this.transform.position = player.transform.position + offset;

		else if (gameManager.currentState == GameManager.GameStates.GEARS)
		{
			this.transform.position = powerMiniGame.transform.position + offset;
		}
	}
}
