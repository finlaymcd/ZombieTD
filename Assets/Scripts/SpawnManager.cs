using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {


	public Spawner spawnOne;
	public Spawner spawnTwo;
	public Spawner spawnThree;
	public Spawner spawnFour;
	private float rand;
	public float spawnRate;
	private float t;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (t > spawnRate) {
			spawn ();
			t = 0;
		}
			
		t += Time.deltaTime;
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
