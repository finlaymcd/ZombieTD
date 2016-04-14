using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoutUIItem : MonoBehaviour {

	private string name;
	private Shooter scout;
	public Text scoutName;
	public ScoutManager scoutMan;
	private float startTime;
	private float endTime;

	// Use this for initialization
	void Start () {
		scoutMan = GameObject.Find ("ScoutManager").GetComponent<ScoutManager>();
		startTime = scoutMan.generateTime ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName(string n, Shooter s){
		scout = s;
		name = n;
		scoutName.text = name;
	}

	public void returnScout(){
		scoutMan.returnScout (scout, this, startTime);
	}

	public void setStartTime(float s){
		startTime = s;
	}

	public float getStartTime(){
		return startTime;
	}


}
