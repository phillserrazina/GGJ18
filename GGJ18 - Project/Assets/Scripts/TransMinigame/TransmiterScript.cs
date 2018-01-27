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

	public GameObject wave1;
	public GameObject wave2;
	public GameObject wave3;

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

				wave1.SetActive (true);
				wave2.SetActive (true);
				wave3.SetActive (true);
			}
			else
			{
				
			}
		}
		else
		{
			if(satisfactionMeter > 0)
				satisfactionMeter -= chargeSpeed * 0.5f * Time.deltaTime * gameManager.powerOffCounter;

			wave1.SetActive (false);
			wave2.SetActive (false);
			wave3.SetActive (false);
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
