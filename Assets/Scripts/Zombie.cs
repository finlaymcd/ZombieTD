using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public float speed;
	private int health;
	private int damage;
	private float attackRate; //seconds between each attack
	public Transform targetTransform; //transform of current target
	public Building[] buildings; //array of all Building classes and subclasses in the scene
	public Shooter [] shooters;
	public GameObject currentTarget; //gameobject of current target (this is of GameObject class and not Building class because I potentially want to include humans as a possible target)
	public Vector3 currentPos; //currentPosition
	private float t; //variable that stores time.
	public GameObject model;

	// Use this for initialization
	void Start () {
		t = 0;
		attackRate = 3;
		damage = 1;
		health = 3;
		buildings = FindObjectsOfType (typeof(Building)) as Building[]; //finds all objects of class Building and puts them in an array called buildings
		shooters = FindObjectsOfType(typeof(Shooter)) as Shooter[];
		//targetTransform = GameObject.Find ("WatchTower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime; //time counter
		currentPos = transform.position;
		if(targetTransform == null){ //check if it has a target
			outSight();
			findClosestTarget();
		}
	move ();

	}



		
	public void move(){
		if (targetTransform != null) {
			if (Vector3.Distance (currentPos, targetTransform.position) > 0.2f) { //checks how close the building is. If it's too close, it won't move, and starts attacking it instead (see else)
				float step = speed * Time.deltaTime; //move towards the closest buidling
				Vector3 go = new Vector3(targetTransform.position.x, 11, targetTransform.position.z);
				transform.position = Vector3.MoveTowards (transform.position, go, step); //apply movement
				Vector3 relativePos = targetTransform.position - gameObject.transform.position;
				Quaternion rotation = Quaternion.LookRotation (relativePos);
				gameObject.transform.rotation = rotation;
			} else {
				if (t > attackRate) {
					attack ();
					t = 0; //t is a timer, and gets reset to zero every time it attacks
				}
			}
		}

	}

	public void attack(){
		if(currentTarget.GetComponent<Building>() != null){ //if it has a target
			Building b = currentTarget.GetComponent<Building> (); //save building as variable
			b.loseHealth (damage); //cause that building to lose health
		}
		if(currentTarget.GetComponent<Shooter>() != null){ //if it has a target

			Shooter s = currentTarget.GetComponent<Shooter> (); //save building as variable
			if(s.returnScoutStatus() == false){
			s.removeHealth (damage); //cause that building to lose health
			}
		}
	}

	/*
	 * Finds and sets the closest building for the zombie to attack
	 **/
	public void findClosestTarget(){
		float minDistance = Mathf.Infinity; //minDistance is initially infinite


		foreach(Building b in buildings){ //iterate through all buildings to find the closest
			if (b != null) {
				Transform t = b.transform;
				float dist = Vector3.Distance (currentPos, t.position); //find distance between zombie and current selected building

				if (dist < minDistance) { //set the closest building
					minDistance = dist; //if it's closer than the current mindistance, it becomes the new mindistance and the new target
					targetTransform = t;
					currentTarget = b.gameObject;
				}
			}
		}

		foreach(Shooter s in shooters){ //iterate through all buildings to find the closest
			if (s != null && s.inBuilding == false && s.returnScoutStatus() == false) {
				Transform t = s.transform;
				float dist = Vector3.Distance (currentPos, t.position); //find distance between zombie and current selected building

				if (dist < minDistance) { //set the closest building
					minDistance = dist; //if it's closer than the current mindistance, it becomes the new mindistance and the new target
					targetTransform = t;
					currentTarget = s.gameObject;
				}
			}
		}
	}

	public void setSpeed(int newSpeed){
		speed = newSpeed; //set zombie movement speed
	}

	public float getSpeed(){
		return speed; //no particular reason why this is needed. Just have a habit of putting in a getter when I make a setter
	}

	public void addHealth(int newHealth){
		health += newHealth;
		if(health <= 0){
			Destroy (gameObject); //add or remove health. Projectiles pass in a minus value.
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

	public void inSight(){
		model.SetActive (true);

	}

	public void outSight(){
		//model.SetActive (false);

	}
}
