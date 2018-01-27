using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	// VARIABLES

	public TileScript[] tiles;
	public PositionScript[] positions;

	private TileScript tile;
//	private PositionScript position;

	public List<int> positionList;

	// FUNCTIONS

	void Start () 
	{
		tiles = GameObject.FindObjectsOfType<TileScript> ();
		positions = GameObject.FindObjectsOfType<PositionScript> ();

		tile = GameObject.FindObjectOfType<TileScript> ();
//		position = GameObject.FindObjectOfType<PositionScript> ();

		for (int i = 0; i < positions.Length; i++)
		{
			positionList.Add (i);
		}

		foreach (PositionScript position in positions) 
		{
			for (int i = 0; i < positions.Length; i++)
			{
				if (position.name == ("Position (" + i + ")").ToString ()) 
				{
					position.positionNumber = i;
				}
			}
		}

		for(int i = 0; i < tiles.Length; i++)
		{
			

			int chosenNumber = positionList[ Mathf.RoundToInt (Random.Range (0f, (positionList.Count - 1)))];

			tiles [i].transform.position = positions [chosenNumber].transform.position;

			tiles [i].tileNumber = chosenNumber;

			positionList.Remove (chosenNumber);
		}	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
