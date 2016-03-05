using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour {


	//public GameObject can;
	public Building phresh;
	public Canvas canvas;


	


	public void build(Building b){
		phresh = Instantiate (b);
		//phresh.transform.position = new Vector3 ();

		canvas.enabled = false;
	
	}

	public void setCanvasActive(){
		canvas.enabled = true;
	}




}
