using UnityEngine;
using System.Collections;

public class PositionalRounding : MonoBehaviour {

	private float newX;
	private float newZ;

	// Use this for initialization
	void Start(){
		rePosition ();
	}


	public void rePosition(){
		//for (int i = 0; i < 3; i++) { //cheap fix. Sometimes doesn't work the first time, so just run it a couple more times.
			float currentX = transform.position.x;
			
			
		float offSetX = (currentX % 0.25f); //
			if (offSetX >= 0.125) {
				float x = 0.25f - offSetX;
				newX = transform.position.x + x;
			} else {
				newX = transform.position.x - offSetX;
			}

			if (newX > 4.75f) {
				newX = 4.75f;
			}
			if(newX < -4.75f){
				newX = -4.75f;
			}

			float currentZ = transform.position.z;
			

		float offSetZ = (currentZ % 0.25f); 
			if (offSetZ >= 0.125) {
				float z = 0.25f - offSetZ;
				newZ = transform.position.z + z;
			} else {
				newZ = transform.position.z - offSetZ;
			}

			if (newZ > 4.75f) {
				newZ = 4.75f;
			}
			if (newZ < -4.75f) {
				newZ = -4.75f;
			}
			transform.position = new Vector3 (newX, transform.position.y, newZ);
		//}
	}
}
