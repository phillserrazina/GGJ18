using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if(SceneManager.GetActiveScene().name == "MenuScene")
			FindObjectOfType<AudioManager> ().Play ("SillyString");
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene ("MainScene");
	}

	public void Instructions()
	{
		SceneManager.LoadScene ("Instructions");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void Menu()
	{
		SceneManager.LoadScene ("MenuScene");
	}
}
