using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	public int maxHealth;
	public int health;
	public int capacity;
	public int numberResidents;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addOccupant(){
		if(numberResidents < capacity){
		numberResidents++;
		}
	}

	public void removeOccupant(){
		numberResidents--;
	}

	public void loseHealth(int damage){
		health -= damage;
	}

	public void addHealth(int aid){
		if(health < maxHealth){
		health += aid;
			if (health > maxHealth) {
				health = maxHealth;
			}
		}
	}
}
