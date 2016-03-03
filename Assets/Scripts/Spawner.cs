using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour {


	private bool spawning;
	public float Top;
	public float Bottom;
	public float zSpawn; 
	public bool onXaxis;
	public GameObject zomba;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame




	public void setSpawning(bool isSpawning){
		spawning = isSpawning;
	}

	public void spawn(){
		if (!onXaxis) { //check if its on the x axis or the z axis.
			Vector3 spawnPos = new Vector3 (transform.position.x, transform.position.y, Random.Range (-5.0f, 5.0f));  //spawn anywhere between those values, locked on the other two axes.
			Instantiate (zomba, spawnPos, transform.rotation); //instantiate function takes the prefab, the position, and the rotation.
		} 
		else {
			Vector3 spawnPos = new Vector3 (Random.Range (-5.0f, 5.0f), transform.position.y, transform.position.z);  //same again, but on the other axes.
			Instantiate (zomba, spawnPos, transform.rotation);
		}

	}
}
