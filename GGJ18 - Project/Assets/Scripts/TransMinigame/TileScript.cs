using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

	// VARIABLES

	public int tileNumber = 0;

	// FUNCTIONS

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if(this.gameObject.name == "Tile (11)")
		{
			foreach(PositionScript position in GameObject.FindObjectOfType<TileManager>().positions)
			{
				if(this.gameObject.transform.position == position.transform.position)
				{
					position.isFree = true;
				}
			}
		}
	}
}
