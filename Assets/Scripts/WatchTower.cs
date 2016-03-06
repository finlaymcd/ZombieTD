using UnityEngine;
using System.Collections;

public class WatchTower : Building {
						//^^^^^^^^

	/*
	 * Inherits from Building (see above). Sets variables to watchtowers.
	 * */



	// Use this for initialization
	void Start () {
		maxHealth = 8;
		health = maxHealth;
		capacity = 3;
		height = 11.75f;

	}
	
	// Update is called once per frame

}
