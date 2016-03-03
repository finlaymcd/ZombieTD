using UnityEngine;
using System.Collections;

public class PositionalRounding : MonoBehaviour {

	private float newX;
	private float newZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			rePosition ();
		}
	}

	public void rePosition(){
		float currentX = transform.position.x;
		if (currentX < 0) {
			currentX = currentX * -1;
		}
		float offSetX = (currentX % 0.25f); 
		if (offSetX >= 0.125 ) {
			newX = transform.position.x - offSetX;
		} 
		else {
			newX = transform.position.x + offSetX;
		}


		float currentZ = transform.position.z;
		float offSetZ = (currentZ % 0.25f); 
		if (offSetZ >= 0.125) {
			newZ = transform.position.z - offSetZ;
		} 
		else {
			newZ = transform.position.z - offSetZ;
		}

		transform.position = new Vector3 (newX, transform.position.y, newZ);
	}
}
