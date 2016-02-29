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
		if (onXaxis) {
			Vector3 spawnPos = new Vector3 (transform.position.x, transform.position.y, Random.Range (-12.0f, -3.0f)); 
			Instantiate (zomba, spawnPos, transform.rotation);
		} 
		else {
			Vector3 spawnPos = new Vector3 (Random.Range (-6.0f, 2.5f), transform.position.y, transform.position.z); 
			Instantiate (zomba, spawnPos, transform.rotation);
		}

	}
}
