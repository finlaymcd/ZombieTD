using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Building : MonoBehaviour {

	/*
	 * This is the parent class that all buildings and structures will inherit from.
	 * */


	public int maxHealth;
	public int health;
	public int capacity;
	public int numberResidents;
	public bool canEdit;
	public int woodCost;
	public List<Shooter> shooters;
	public float height;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addOccupant(Shooter s){ //add a person in to the building
		if(numberResidents < capacity){
			shooters.Add (s);
			s.gameObject.transform.position = new Vector3 (transform.position.x, height, transform.position.z);
			s.sightRange = s.sightRange * 2;
			s.setLight ();
			numberResidents++;
		}
	}

	public void removeOccupant(Shooter s){ //remove person from building
		foreach (Shooter shoot in shooters) {
			if (shoot == s) {
				shooters.Remove (shoot);
				s.sightRange = s.sightRange / 2;
			}
		}
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
		gameObject.tag = "Draggable";
		Button b = gameObject.GetComponentInChildren<Button> ();
		b.gameObject.SetActive (false);
		canEdit = true;
	}

	public void setUnEditable(){
		gameObject.tag = "Untagged";
		Button b = gameObject.GetComponentInChildren<Button> ();
		b.gameObject.SetActive (false);
		canEdit = false;
	}


}
