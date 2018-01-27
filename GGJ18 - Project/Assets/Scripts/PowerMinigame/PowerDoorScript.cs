using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDoorScript : MonoBehaviour {

	void OnTriggerStay()
	{
		if(Input.GetKey(KeyCode.Z) && (GameObject.FindObjectOfType<GameManager> ().currentState == GameManager.GameStates.WALK))
		{
			GameObject.FindObjectOfType<GameManager> ().currentState = GameManager.GameStates.GEARS;
		}
	}
}
