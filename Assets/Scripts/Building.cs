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
	public int metalCost;


	public void addOccupant(Shooter s){ //add a person in to the building
		if(numberResidents < capacity && canEdit == false){
			shooters.Add (s);

			s.gameObject.transform.position = new Vector3 (transform.position.x, height, transform.position.z);
			s.transform.parent = gameObject.transform;
			s.sightRange = s.sightRange * 2;

			s.occupiedBuilding = this;
			s.inBuilding = true;
			numberResidents++;
			s.setLight ();
			s.repositionLight ();
		}
	}

	public void removeOccupant(Shooter s){ //remove person from building
		numberResidents--;
		foreach (Shooter shoot in shooters) {
			if (shoot == s) {
				
				s.transform.parent = null;
				s.occupiedBuilding = null;
				s.inBuilding = false;
				shooters.Remove (shoot);
				s.sightRange = s.sightRange / 2;
				s.setLight ();
				s.resetLight();
				break;
			}
		}

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
