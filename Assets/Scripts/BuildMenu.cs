using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour {


	//public GameObject can;
	public Building phresh;
	public Image baseMenu;
	public GameManager man;
	private Button [] buttons;

	


	void Start(){
		buttons = gameObject.GetComponentsInChildren<Button> ();

	}

	public void build(Building b){
		phresh = Instantiate (b);
		if (phresh.woodCost > man.gotWood() || phresh.metalCost > man.gotMetal()) {
			Destroy (phresh.gameObject);
		} else {
			phresh.GetComponent<PositionalRounding> ().rePosition ();
			man.removeWood (phresh.woodCost);
			man.removeMetal (phresh.metalCost);
			closeMenu ();

		}
	
	}

	public void closeMenu(){
		gameObject.SetActive (false);

	}

	public void setMenuActive(){
		Debug.Log ("called");
		gameObject.SetActive (true);
		buttons = gameObject.GetComponentsInChildren<Button> ();
		foreach(Button b in buttons){
			string s = b.gameObject.name;
			if (s == "Tower") {
				if (man.gotWood () < 10) {
					b.interactable = false;
					//Image i = b.gameObject.GetComponent<Image> ();
					//i.canvasRenderer.SetAlpha (0.1f);
				} else {
					b.interactable = true;
				}
			}

			if(s == "Wall"){
				if (man.gotMetal () < 5) {
					b.interactable = false;
				} 
				else {
					b.interactable = true;
				}
			}
		}
	}




}
