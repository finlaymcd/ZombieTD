using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {


	public Spawner spawnOne;
	public Spawner spawnTwo;
	public Spawner spawnThree;
	public Spawner spawnFour;
	private float rand;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) { //when space is pressed
			spawn ();
		}
	}

	public void spawn(){ //spawn from one of the for spawner objects (these were passed to the SpawnManager in the editor by dragginf them in)
		rand = Random.Range (0.0f, 80.0f);
		if (rand < 20) {
			spawnOne.spawn ();
		} else if (rand < 40) {
			spawnTwo.spawn ();
		}
		else if(rand < 60){
			spawnThree.spawn ();
		}
		else if(rand < 80){
			spawnFour.spawn();
		}
	}
}
