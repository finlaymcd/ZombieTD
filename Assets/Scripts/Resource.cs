using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {


	public int amountContained = 5;
	private string resourceType;




	public void removeResource(int a, Shooter s){
		Debug.Log ("a = " + a);
		if (a > amountContained) {
			a = amountContained;
		}
		amountContained -= a;
		s.addResource (a);
		//return b;
		if(amountContained <= 0){
			if(gameObject != null){
			Destroy (gameObject);
			}
		}

	}





}
