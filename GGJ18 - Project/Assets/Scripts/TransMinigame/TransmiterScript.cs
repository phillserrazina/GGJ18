using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmiterScript : MonoBehaviour {

	// VARIABLES

	public float satisfactionMeter = 100.0f;
	public float score;

	private float chargeSpeed = 1.0f;
	private bool isNear = false;

	private GameManager gameManager;

	public Text satisfactionText;
	public Text scoreText;

	// FUNCTIONS

	void Start()
	{
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}


	void Update()
	{
		satisfactionText.text = satisfactionMeter.ToString ("F0");
		scoreText.text = score.ToString ("F0");

		if(Input.GetKey(KeyCode.C) && GameObject.FindObjectOfType<RadioScript>().powerOn == true)
		{
			if(isNear == true)
			{
				if(satisfactionMeter < 100)
					satisfactionMeter += chargeSpeed * Time.deltaTime * gameManager.powerOffCounter * 4f;

				score += chargeSpeed * Time.deltaTime * gameManager.powerOffCounter;
			}
			else
			{
				
			}
		}
		else
		{
			if(satisfactionMeter > 0)
				satisfactionMeter -= chargeSpeed * 0.5f * Time.deltaTime * gameManager.powerOffCounter;
		}
	}

	void OnTriggerEnter ()
	{
		isNear = true;
	}

	void OnTriggerExit()
	{
		isNear = false;
	}
}
