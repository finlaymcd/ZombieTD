using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoutMenu : MonoBehaviour {


	public GameManager man;
	public Transform scoutUI;
	private List<ScoutUIItem> scouts = new List<ScoutUIItem>();
	private int scoutCount;
	public RectTransform scroller;

	// Use this for initialization

	void Start () {
		scoutCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScoutUI(Shooter s){
		
		Transform ui = (Instantiate (scoutUI, new Vector3 (0, 0, 0), Quaternion.identity) as Transform);
		ui.parent = GameObject.Find ("ScoutScroll").transform;

		Debug.Log (ui);
		ScoutUIItem UI = ui.gameObject.GetComponentInChildren<ScoutUIItem> ();
		RectTransform recta = UI.gameObject.GetComponent<RectTransform> ();
		float yPos = -50;
		for(int i = 0; i < scoutCount; i++){
			yPos -= 150;
		}
		if(scoutCount >= 4){
		scroller.sizeDelta = new Vector2(scroller.sizeDelta.x, scroller.sizeDelta.y + 150);
		}
		recta.anchoredPosition = new Vector2 (0, yPos);
		UI.setName (s.getName());
		scoutCount++;
	}

	public void removeScoutUI(){

	}

	public void closeScoutMenu(){
		gameObject.SetActive (false);
	}

	public void openScoutMenu(){
		gameObject.SetActive (true);
	}


}
