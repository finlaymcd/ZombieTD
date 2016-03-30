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
					Debug.Log ("mah");
					Vector3 newPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z + 0.2f );
					gameObject.transform.position = newPos;
					amountContained = 5;
				}
				if (position == "w") {

				}
				if(position == "e"){

				}
				if(position == "s"){

				}
			}
		}

	}





}
