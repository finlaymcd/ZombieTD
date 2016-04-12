using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {


	public int amountContained = 5;
	private string resourceType;
	public string position;



	public void removeResource(int a, Shooter s){
		Debug.Log ("a = " + a);
		if (a > amountContained) {
			a = amountContained;
		}
		amountContained -= a;
		s.addResource (a);
		//return b;
		if(amountContained == 0){
			if(gameObject != null){
				Vector3 currentPos = gameObject.transform.position;
				if(position == "n"){
					Vector3 newPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z + 0.1f );
					gameObject.transform.position = newPos;
					amountContained = 5;
				}
				if (position == "w") {
					Vector3 newPos = new Vector3 (currentPos.x - 0.1f , currentPos.y, currentPos.z );
					gameObject.transform.position = newPos;
					amountContained = 5;
				}
				if(position == "e"){
					Vector3 newPos = new Vector3 (currentPos.x + 0.1f , currentPos.y, currentPos.z );
					gameObject.transform.position = newPos;
					amountContained = 5;
				}
				if(position == "s"){
					Vector3 newPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z - 0.1f );
					gameObject.transform.position = newPos;
					amountContained = 5;
				}
			}
		}

	}





}
