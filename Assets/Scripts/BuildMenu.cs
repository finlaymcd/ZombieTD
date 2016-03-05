using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour {


	//public GameObject can;
	public Building phresh;
	public Image baseMenu;
	public GameManager man;


	


	public void build(Building b){
		phresh = Instantiate (b);
		if (phresh.woodCost > man.gotWood()) {
			Destroy (phresh.gameObject);
		} else {
			phresh.GetComponent<PositionalRounding> ().rePosition ();
			man.removeWood (phresh.woodCost);
			gameObject.SetActive (false);

		}
	
	}

	public void setMenuActive(){
		gameObject.SetActive (true);
	}




}
