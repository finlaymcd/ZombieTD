using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {


	private int amountContained = 5;
	private string resourceType;




	public void removeResource(int a){
		amountContained -= a;
		if(amountContained < 0){
			Destroy (gameObject);
		}
	}
}
