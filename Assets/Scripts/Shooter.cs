using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public Projectile projectile;
	private float shootTime;
	private float t;

	void Start () {
		shootTime = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("ZombiePrefab(Clone)")){
			if(t >= shootTime){
			(Instantiate (projectile)).setShooter(this.GetComponent<Shooter>()) ;
			t = 0;
			}
		}
		t += Time.deltaTime;
	}




}

