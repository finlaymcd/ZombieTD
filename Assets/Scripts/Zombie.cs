using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	private int speed;
	private int health;
	private int damage;
	private BoxCollider body;
	public Transform towerTransform;
	public Building[] buildings;

	// Use this for initialization
	void Start () {
		health = 3;
		body = gameObject.GetComponent<BoxCollider> ();
		speed = 1;
		buildings = FindObjectsOfType (typeof(Building)) as Building[];
		Debug.Log (buildings.Length);
		//towerTransform = GameObject.Find ("WatchTower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(towerTransform == null){ //check if it has a target
			findClosestBuilding();
		}
		
		float step = speed * Time.deltaTime; //move towards the closest buidling
		transform.position = Vector3.MoveTowards (transform.position, towerTransform.position, step);
	}

	/*
	 * Finds and sets the closest building for the zombie to attack
	 **/
	public void findClosestBuilding(){
		float minDistance = Mathf.Infinity;
		Vector3 currentPos = transform.position;

		foreach(Building b in buildings){ //iterate through all buildings to find the closest
			Transform t = b.transform;
			float dist = Vector3.Distance (currentPos, t.position);

			if (dist < minDistance) { //set the closest building
				minDistance = dist;
				towerTransform = t;
			}
		}
	}

	public void setSpeed(int newSpeed){
		speed = newSpeed;
	}

	public int getSpeed(){
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
