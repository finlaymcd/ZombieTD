using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	private int speed;
	private int health;
	private int damage;
	private BoxCollider body;
	public Transform towerTransform;

	// Use this for initialization
	void Start () {
		health = 3;
		body = gameObject.GetComponent<BoxCollider> ();
		speed = 1;
		towerTransform = GameObject.Find ("WatchTower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, towerTransform.position, step);
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
