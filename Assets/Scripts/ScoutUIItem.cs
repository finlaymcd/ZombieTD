using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoutUIItem : MonoBehaviour {

	private string name;
	private Shooter scout;
	public Text scoutName;
	public Text buttonText;
	public Button butt;
	public ScoutManager scoutMan;
	private float startTime;
	private float endTime;
	private bool returning;
	private float returnTime;


	// Use this for initialization
	void Start () {
		returning = false;
		scoutMan = GameObject.Find ("ScoutManager").GetComponent<ScoutManager>();
		butt = gameObject.GetComponentInChildren<Button>();
		buttonText = butt.GetComponentInChildren<Text> ();
		startTime = scoutMan.generateTime ();
	}
	
	// Update is called once per frame
	void Update () {
		if(returning){
			returnTime -= Time.deltaTime;
			if(returnTime <= 0){
				scoutMan.returnScout (scout, this, startTime);
			}
		}
	}

	public void setName(string n, Shooter s){
		scout = s;
		name = n;
		scoutName.text = name;
	}

	public void returnScout(){
		returnTime = scoutMan.generateTime () - startTime;
		returning = true;
		buttonText.text = "Scout Returning";
		butt.interactable = false;

	}

	public void setStartTime(float s){
		startTime = s;
	}

	public float getStartTime(){
		return startTime;
	}


}
