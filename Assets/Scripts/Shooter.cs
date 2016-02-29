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
			foreach(Zombie z in zombies){ //iterate through all buildings to find the closest
				if (z != null) {
					Transform trans = z.gameObject.transform;
					float dist = Vector3.Distance (currentPos, trans.position);
					if (dist < minDistance) { //set the closest building
						minDistance = dist;
						target = z;

					}
				}
			}

			}

		if (GameObject.Find("ZombiePrefab(Clone)")){
			if(t >= shootTime){
			(Instantiate (projectile)).setShooter(this.GetComponent<Shooter>(), target) ;
			t = 0;
				shootTime = Random.Range (2, 5);
			}
		}
		t += Time.deltaTime;
	}






}

