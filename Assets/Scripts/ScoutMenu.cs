using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoutMenu : MonoBehaviour {


	public GameManager man;
	public Transform scoutUI;
	private List<ScoutUIItem> scouts = new List<ScoutUIItem>();
	private int scoutCount;
	private bool menuOpen;
	public RectTransform scroller;

	// Use this for initialization

	void Start () {
		scoutCount = 0;

		closeScoutMenu ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void addScoutUI(Shooter s){
		
		Transform ui = (Instantiate (scoutUI, new Vector3 (0, 0, 0), Quaternion.identity) as Transform);
		ui.parent = GameObject.Find ("ScoutScroll").transform;
		ScoutUIItem UI = ui.gameObject.GetComponentInChildren<ScoutUIItem> ();

		RectTransform recta = UI.gameObject.GetComponent<RectTransform> ();
		float yPos = -50;
		for(int i = 0; i < scoutCount; i++){
			yPos -= 150;
		}
		if(scoutCount >= 4){
		scroller.sizeDelta = new Vector2(scroller.sizeDelta.x, scroller.sizeDelta.y + 180);
		}
		recta.anchoredPosition = new Vector2 (0, yPos);
		UI.setName (s.getName(), s);
		if(menuOpen == false){
			Image[] scoutUIimage = ui.gameObject.GetComponentsInChildren<Image>();
			Text[] scoutUItext = ui.gameObject.GetComponentsInChildren<Text>();
			foreach(Image i in scoutUIimage){
				i.enabled = false;
			}
			foreach(Text t in scoutUItext){
				t.enabled = false;
			}
		}
		scoutCount++;
	}

	public void removeScoutUI(){
		scroller.sizeDelta = new Vector2(scroller.sizeDelta.x, scroller.sizeDelta.y - 180);
		foreach(ScoutUIItem s in scouts){
			//move them up 180

		}
	}

	public void closeScoutMenu(){
		
		Image[] scoutUI = gameObject.GetComponentsInChildren<Image>();
		Text[] scoutUItext = gameObject.GetComponentsInChildren<Text>();
		foreach(Image i in scoutUI){
			i.enabled = false;
		}
		foreach(Text t in scoutUItext){
			t.enabled = false;
		}
		menuOpen = false;
	}

	public void openScoutMenu(){

		Image[] scoutUI = gameObject.GetComponentsInChildren<Image>();
		Text[] scoutUItext = gameObject.GetComponentsInChildren<Text>();
		foreach(Image i in scoutUI){
			i.enabled = true;
		}
		foreach(Text t in scoutUItext){
			t.enabled = true;
		}
		menuOpen = true;
	}


}
