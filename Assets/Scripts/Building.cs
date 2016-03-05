using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Building : MonoBehaviour {

	/*
	 * This is the parent class that all buildings and structures will inherit from.
	 * */


	public int maxHealth;
	public int health;
	public int capacity;
	public int numberResidents;
	public bool canEdit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addOccupant(){ //add a person in to the building
		if(numberResidents < capacity){
		numberResidents++;
		}
	}

	public void removeOccupant(){ //remove person from building
		numberResidents--;
	}

	public void loseHealth(int damage){ // remove building health
		health -= damage;
		if(health <= 0){
			Destroy (gameObject);
		}
	}

	public void addHealth(int aid){ //add building health
		if(health < maxHealth){
		health += aid;
			if (health > maxHealth) {
				health = maxHealth;
			}
		}
	}

	public void setEditable(){
		Button b = gameObject.GetComponentInChildren<Button> ();
		b.gameObject.SetActive (false);
		canEdit = true;
	}

	public void setUnEditable(){
		Button b = gameObject.GetComponentInChildren<Button> ();
		b.gameObject.SetActive (false);
		canEdit = false;
	}
}
