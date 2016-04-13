using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoutUIItem : MonoBehaviour {

	private string name;
	public Text scoutName;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName(string n){
		name = n;
		scoutName.text = name;
	}
}
