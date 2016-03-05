using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour {


	//public GameObject can;
	public Building phresh;
	public Image baseMenu;
	public Canvas canvas;


	


	public void build(Building b){
		phresh = Instantiate (b);
		phresh.GetComponent<PositionalRounding> ().rePosition();
		canvas.enabled = false;
	
	}

	public void setCanvasActive(){
		canvas.enabled = true;
	}




}
