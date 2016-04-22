using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoutManager : MonoBehaviour {

	private List<Shooter> scouts = new List<Shooter>();
	public GameManager gameMan;
	public ScoutMenu scoutUI;
	private float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(scouts.Count >= 1){
		time += Time.deltaTime;
		}

	}

	public float generateTime(){
		return time;
	}

	public void addScout(Shooter s){
		scoutUI.addScoutUI (s);
		scouts.Add (s);
		MeshRenderer[] visible = s.gameObject.GetComponentsInChildren<MeshRenderer> ();
		foreach(MeshRenderer m in visible){
			m.enabled = false;
		}
	}

	public void returnScout(Shooter s, ScoutUIItem item, float startTime){
		float totalTime = time - startTime;
		reapReward (totalTime);
		foreach(Shooter shoot in scouts){
			if(shoot == s){
				s.returnFromScout ();
				scoutUI.removeScoutUI ();
				MeshRenderer[] visible = s.gameObject.GetComponentsInChildren<MeshRenderer> ();
				foreach(MeshRenderer m in visible){
					m.enabled = true;
				}
			}
		}

		scouts.Remove (s);
		destroyUIitem (item);
		if (scouts.Count == 0) {
			time = 0;
		}
	}

	public void destroyUIitem(ScoutUIItem item){
		Destroy (item.gameObject);
	}

	public void reapReward(float timeOut){

		int woodFound = 0;
		float woodChance = Random.Range (10, 40);
		woodFound = Mathf.RoundToInt (timeOut/woodChance);

		int metalFound = 0;
		float metalChance = Random.Range (20, 100);
		metalFound = Mathf.RoundToInt (timeOut/metalChance);

		int survivorsFound = 0;
		float survivorChance = Random.Range (50, 500);
		survivorsFound = Mathf.RoundToInt (timeOut/survivorChance);

		gameMan.addWood (woodFound);
		gameMan.addMetal (metalFound);
		for (int i = 0; i < survivorsFound; i++) {
			gameMan.createShooter ();
		}

		Debug.Log ("wood: " + woodFound);
		Debug.Log ("metal: " + metalFound);
		Debug.Log ("survivors " + survivorsFound);
	}
}
