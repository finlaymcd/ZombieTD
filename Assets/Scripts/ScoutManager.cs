using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoutManager : MonoBehaviour {

	private List<Shooter> scouts = new List<Shooter>();
	public ScoutMenu scoutUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScout(Shooter s){
		scoutUI.addScoutUI (s);
		scouts.Add (s);
		MeshRenderer[] visible = s.gameObject.GetComponentsInChildren<MeshRenderer> ();
		foreach(MeshRenderer m in visible){
			m.enabled = false;
		}
	}
}
