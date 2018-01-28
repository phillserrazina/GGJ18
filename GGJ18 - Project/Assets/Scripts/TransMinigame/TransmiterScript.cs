using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmiterScript : MonoBehaviour {

	// VARIABLES

	public float satisfactionMeter = 100.0f;
	public float score;

	public int powerUpCounter = 3;

	private float chargeSpeed = 1.0f;
	private bool isNear = false;
	private bool isPressing = false;
	private bool isPressingC = false;

	private GameManager gameManager;

	public Text satisfactionText;
	public Text scoreText;
	public Text batteryText;

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
		batteryText.text = powerUpCounter.ToString ();

		if(Input.GetKey(KeyCode.C))
		{
			if(isPressingC == false)
			{
				isPressingC = true;

				if(powerUpCounter > 0)
				{
					satisfactionMeter = 100f;
					powerUpCounter--;
				}
			}
		}

		else
		{
			isPressingC = false;
		}

		if(Input.GetKey(KeyCode.Z) && GameObject.FindObjectOfType<RadioScript>().powerOn == true)
		{
			if(isNear == true)
			{
				if(satisfactionMeter < 100)
					satisfactionMeter += chargeSpeed * Time.deltaTime * gameManager.powerOffCounter * 4f;

				score += chargeSpeed * Time.deltaTime * gameManager.powerOffCounter;

				wave1.SetActive (true);
				wave2.SetActive (true);
				wave3.SetActive (true);



				if (isPressing == false) {
					if (GameObject.FindObjectOfType<RadioScript>().x <= 0.3f) {
						FindObjectOfType<AudioManager> ().Play ("StayInside");
						isPressing = true;
					} else if (GameObject.FindObjectOfType<RadioScript>().x > 0.3f && GameObject.FindObjectOfType<RadioScript>().x <= 0.6f) {
						FindObjectOfType<AudioManager> ().Play ("BlackVirus");
						isPressing = true;
					} else {
						FindObjectOfType <AudioManager> ().Play ("Infected");
						isPressing = true;
					}
				}
			}
			else
			{
				
			}
		}
		else
		{
			if(satisfactionMeter > 0)
				satisfactionMeter -= chargeSpeed * 1.5f * Time.deltaTime * gameManager.powerOffCounter;

			wave1.SetActive (false);
			wave2.SetActive (false);
			wave3.SetActive (false);

			if (isPressing == true) {
				if (GameObject.FindObjectOfType<RadioScript>().x <= 0.3f) {
					FindObjectOfType<AudioManager> ().Stop ("StayInside");
					isPressing = false;
				} else if (GameObject.FindObjectOfType<RadioScript>().x > 0.3f && GameObject.FindObjectOfType<RadioScript>().x <= 0.6f) {
					FindObjectOfType<AudioManager> ().Stop ("BlackVirus");
					isPressing = false;
				} else {
					FindObjectOfType <AudioManager> ().Stop ("Infected");
					isPressing = false;
				}
			}
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
