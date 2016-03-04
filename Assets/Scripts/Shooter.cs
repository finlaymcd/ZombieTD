using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public Projectile projectile;
	private float shootTime;
	private float t;
	private Zombie target;
	private Zombie[] zombies;
	private Vector3 currentPos;
	public double sightRange;
	public Light sight;
	private bool zombiesNear = false;
	private float searchTimer;

	void Start () {
		sight = gameObject.GetComponentInChildren<Light> ();
		shootTime = 1;
		setLight ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(target == null){
			currentPos = transform.position;
			float minDistance = Mathf.Infinity;
			zombies = FindObjectsOfType (typeof(Zombie)) as Zombie[];
			foreach(Zombie z in zombies){ //iterate through all zombies to find the closest
				if (z != null) { //make sure there are some zombies in scene
					Transform trans = z.gameObject.transform;
					float dist = Vector3.Distance (currentPos, trans.position);
					if (dist < minDistance) { //set the closest zombie
						minDistance = dist;
						target = z;

					}
				}
			}
		}

		if (t >= shootTime) { //if a few seconds have passed
			shoot ();
		}


		if (t > 1.0) {
			scanForZombies ();
		}


		t += Time.deltaTime; //increment time

	}



	public void shoot(){
		if (GameObject.Find("ZombiePrefab(Clone)")){ //if there is a zombie in scene
			if((Vector3.Distance(currentPos, target.gameObject.transform.position)) <= sightRange){
				target.inSight ();
				(Instantiate (projectile)).setShooter(this.GetComponent<Shooter>(), target) ;//instantiate projectile, and immediately call the setShooter method on that projectile, passing in this game object, and the nearest zombie as target.
				t = 0; //reset timer to 0
				shootTime = 1; //set new random shoot time.
				}
			}
	}

	public void setLight(){
		if (sightRange <= 1.0) {
			sight.spotAngle = 40;
		} else if (sightRange <= 1.5) {
			sight.spotAngle = 55;
		} else if (sightRange <= 2.0) {
			sight.spotAngle = 70;
		} else if (sightRange <= 2.5) {
			sight.spotAngle = 85;
		} else if (sightRange <= 3.0) {
			sight.spotAngle = 100;
		} else if (sightRange <= 3.5) {
			sight.spotAngle = 115;
		} else if (sightRange <= 4.0) {
			sight.spotAngle = 130;
		} else {
			sight.spotAngle = 140;
		}
	}

	public void scanForZombies(){ // if there are zombies near, checked every 1 second
		zombies = FindObjectsOfType (typeof(Zombie)) as Zombie[];
		foreach(Zombie z in zombies){
			if((Vector3.Distance(currentPos, z.gameObject.transform.position)) <= sightRange){
				z.inSight ();
				if (target.m.enabled != true) {
					target = z;
				}
			}
		}

	}



}