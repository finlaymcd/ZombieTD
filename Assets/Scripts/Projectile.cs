using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


	private Rigidbody rigid;
	private Shooter shoot;
	private Transform target;
	private int damage;
	private float lifetime;



	void Start () {
		
		lifetime = 2;
		damage = -1;
		//zom = GameObject.Find ("ZombiePrefab(Clone)");
		rigid = gameObject.GetComponent<Rigidbody> ();
		Vector3 v = new Vector3 (shoot.transform.position.x, shoot.transform.position.y + 0.4f, shoot.transform.position.z);
		transform.position = v;
		Vector3 relativePos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		transform.rotation = rotation;
		rigid.AddRelativeForce(0,0,500);
	}


	public void fire(){
		
	}
	// Update is called once per frame
	void Update () {
		
		if(lifetime <= 0){
			Destroy (gameObject);
		}

		lifetime -= Time.deltaTime;
	}

	public void setShooter(Shooter shooter, Zombie z){
		target = z.transform;
		shoot = shooter;
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("Collide");
		if (col.gameObject.GetComponent<Zombie> () != null) {
			Zombie zombie = col.gameObject.GetComponent<Zombie> ();
			zombie.addHealth (damage);
			Destroy (gameObject);
		}
	}

}
