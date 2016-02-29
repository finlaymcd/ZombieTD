using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float speed;
	private int health;
	private int damage;
	private float attackRate;
	private BoxCollider body;
	public Transform towerTransform;
	public Building[] buildings;
	public GameObject currentTarget;
	public Vector3 currentPos;
	private float t;

	// Use this for initialization
	void Start () {
		t = 0;
		attackRate = 3;
		damage = 1;
		health = 3;
		body = gameObject.GetComponent<BoxCollider> ();
		buildings = FindObjectsOfType (typeof(Building)) as Building[];
		//towerTransform = GameObject.Find ("WatchTower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		currentPos = transform.position;
		if(towerTransform == null){ //check if it has a target
			findClosestBuilding();
		}
	move ();

	}



		
	public void move(){
		if (Vector3.Distance (currentPos, towerTransform.position) > 0.45f) {
			float step = speed * Time.deltaTime; //move towards the closest buidling
			transform.position = Vector3.MoveTowards (transform.position, towerTransform.position, step);
		} else {
			if (t > attackRate) {
				attack ();
				t = 0;
			}
		}

	}

	public void attack(){
		Debug.Log ("ATTACKING");
		if(currentTarget.GetComponent<Building>() != null){
			Building b = currentTarget.GetComponent<Building> ();
			b.loseHealth (damage);
		}
	}

	/*
	 * Finds and sets the closest building for the zombie to attack
	 **/
	public void findClosestBuilding(){
		float minDistance = Mathf.Infinity;


		foreach(Building b in buildings){ //iterate through all buildings to find the closest
			if (b != null) {
				Transform t = b.transform;
				float dist = Vector3.Distance (currentPos, t.position);

				if (dist < minDistance) { //set the closest building
					minDistance = dist;
					towerTransform = t;
					currentTarget = b.gameObject;
				}
			}
		}
	}

	public void setSpeed(int newSpeed){
		speed = newSpeed;
	}

	public float getSpeed(){
		return speed;
	}

	public void addHealth(int newHealth){
		health += newHealth;
		if(health <= 0){
			Destroy (gameObject);
		}
	}

	public int getHealth(){
		return health;
	}

	public void setDamage(int newDamage){
		damage = newDamage;
	}

	public int getDamage(){
		return damage;
	}
}
