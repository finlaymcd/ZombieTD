using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public Projectile projectile;
	private float shootTime;
	private float t;
	private Zombie target;
	private Zombie[] zombies;
	private Vector3 currentPos;

	void Start () {
		shootTime = Random.Range (2, 5);
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

		if (GameObject.Find("ZombiePrefab(Clone)")){ //if there is a zombie in scene
			if(t >= shootTime){ //if a few seconds have passed
				(Instantiate (projectile)).setShooter(this.GetComponent<Shooter>(), target) ;//instantiate projectile, and immediately call the setShooter method on that projectile, passing in this game object, and the nearest zombie as target.
			t = 0; //reset timer to 0
				shootTime = Random.Range (2, 5); //set new random shoot time.
			}
		}
		t += Time.deltaTime;
	}






}

