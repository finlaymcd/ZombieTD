using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


	private Rigidbody rigid;
	private Shooter shoot; //The Shooter class that spawned it
	private Transform target; //target zombie
	private int damage;
	private float lifetime; 



	void Start () {
		
		lifetime = 2;
		damage = -1;
		rigid = gameObject.GetComponent<Rigidbody> ();	// reference rigidbody component of self
		Vector3 v = new Vector3 (shoot.transform.position.x, shoot.transform.position.y + 0.4f, shoot.transform.position.z);  //create initial position of projectile to shooter location
		transform.position = v;	 //set position
		Vector3 relativePos = target.position - transform.position;  //Vector3 that points from projectile to target
		Quaternion rotation = Quaternion.LookRotation (relativePos); //turn that vector 3 in to a look rotation.
		transform.rotation = rotation; 	//set the projectiles rotation to the look at rotation 
		rigid.AddRelativeForce(0,0,750); //apply the force in the direction it's facing
	}



	// Update is called once per frame
	void Update () {
		
		if(lifetime <= 0){  
			Destroy (gameObject); //destroy self after a few seconds
		}

		lifetime -= Time.deltaTime; //countdown
	}


	public void setShooter(Shooter shooter, Zombie z){ //called by the shooter that instantiates it and passes a reference of itself to the projectile, for the purposes of transform.
		target = z.transform;
		shoot = shooter;
	}

	void OnTriggerEnter(Collider col){ //hit detection
		if (col.gameObject.GetComponent<Zombie> () != null) { //is it a zombie?
			Zombie zombie = col.gameObject.GetComponent<Zombie> ();
			zombie.addHealth (damage); //pass in the projectiles damage and take that health from the zombie
			Destroy (gameObject); //destroy projectile
		}
	}

}
