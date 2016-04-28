using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	private int wood;
	private int metal;
	private int survivors;
	public Text woodText;
	public Text metalText;
	public Spawner[] spawners;
	public Spawner north;
	public Spawner south;
	public Spawner east;
	public Spawner west;
	private Shooter currentInstantiation;
	public GameObject newShooter;
	public List<string> firstNames = new List<string> ();
	public List<string> lastNames = new List<string> ();

	void Start(){
		spawners = FindObjectsOfType (typeof(Spawner)) as Spawner[];
		wood = 40;
		metal = 0;
		setMetalText ();
		setWoodText ();
		firstNames.Add ("Brent");
		firstNames.Add ("Gary");
		firstNames.Add ("Andreas");
		firstNames.Add ("Lee");
		firstNames.Add ("Christian");
		firstNames.Add ("Simon");
		firstNames.Add ("Dan");
		firstNames.Add ("Richard");
		firstNames.Add ("Horace");
		firstNames.Add ("Gerald");
		firstNames.Add ("Ralph");
		firstNames.Add ("Gordon");
		firstNames.Add ("Jake");
		firstNames.Add ("Craig");
		firstNames.Add ("Boris");
		firstNames.Add ("John");
		firstNames.Add ("Rob");
		firstNames.Add ("Haywood");
		firstNames.Add ("Ben");
		lastNames.Add ("Kemp");
		lastNames.Add ("Hopen");
		lastNames.Add ("McDonald");
		lastNames.Add ("Frausig");
		lastNames.Add ("Perrin");
		lastNames.Add ("Went");
		lastNames.Add ("Smith");
		lastNames.Add ("Taylor");
		lastNames.Add ("Jones");
		lastNames.Add ("Fiddlesworth");
		lastNames.Add("Jelley");
		lastNames.Add("Lexington");
		lastNames.Add ("Fletcher");
		lastNames.Add ("Kane");
		lastNames.Add ("Snow");
		lastNames.Add ("McLellan");
		lastNames.Add ("McGregor");
		lastNames.Add ("Jablome");
		lastNames.Add ("Dover");

	}


	public int gotWood(){
		return wood;
	}

	public int gotMetal(){
		return metal;
	}

	public void addWood(int w){
		wood += w;
		setWoodText();
	}

	public void addMetal(int m){
		metal += m;
		setMetalText();
	}

	public void removeWood(int w){

	wood = wood - w;

		setWoodText();
	}

	public void removeMetal (int m){
		metal -= m;
		setMetalText ();
	}

	public void setWoodText(){
		woodText.text = "wood: " + wood;
	}

	public void setMetalText(){
		metalText.text = "metal: " + metal;
	}
		

	public void createShooter(){
		GameObject newShoot = Instantiate (newShooter, new Vector3 (0, 11, 0), Quaternion.identity) as GameObject;
		currentInstantiation = newShoot.GetComponent<Shooter> ();
	}

	public void expandPlayArea(float expansion, Spawner s){

		foreach(Spawner spawn in spawners){
			if(spawn == s){
				if(s == south){ //south side
					Vector3 newPos = new Vector3(spawn.transform.position.x , spawn.transform.position.y, spawn.transform.position.z - expansion);
					s.transform.position = newPos;
					east.zBottom -= expansion;
					west.zBottom -= expansion;
				}
				if(s == north) { // north side  
					Vector3 newPos = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z + expansion);
					s.transform.position = newPos;
					east.zTop += expansion;
					west.zTop += expansion;
				}
				if(s == west){ // west side
					Vector3 newPos = new Vector3(spawn.transform.position.x - expansion, spawn.transform.position.y, spawn.transform.position.z);
					s.transform.position = newPos;
					south.xBottom -= expansion;
					north.xBottom -= expansion;

				}
				if (s == east) { // east side (motherfucker)
					Vector3 newPos = new Vector3(spawn.transform.position.x + expansion, spawn.transform.position.y, spawn.transform.position.z);
					s.transform.position = newPos;
					south.xTop += expansion;
					north.xTop += expansion;
				}

			}
		}

	}
	public string generateName(){
		string firstN = firstNames [Mathf.RoundToInt (Random.Range (0, 18))];
		string lastN = lastNames [Mathf.RoundToInt (Random.Range (0 , 18))];
		string n = firstN + " " + lastN;
		Debug.Log (n);
		return n;
	}
		


}
