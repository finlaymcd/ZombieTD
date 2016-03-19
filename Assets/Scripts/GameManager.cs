using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	private int wood;
	private int survivors;
	public Text woodText;
	public Spawner[] spawners;
	public Spawner north;
	public Spawner south;
	public Spawner east;
	public Spawner west;

	void Start(){
		spawners = FindObjectsOfType (typeof(Spawner)) as Spawner[];
		wood = 5;
		setWoodText();
	}


	public int gotWood(){
		return wood;
	}

	public void addWood(int w){
		wood += w;
		setWoodText();
	}

	public void removeWood(int w){

	wood = wood - w;

		setWoodText();
	}

	public void setWoodText(){
		woodText.text = "wood: " + wood;
	}

	public void expandPlayArea(float expansion, Spawner s){

		foreach(Spawner spawn in spawners){
			if(spawn == s){
				if(s == south){ //south side
					Debug.Log("south");
					Vector3 newPos = new Vector3(spawn.transform.position.x , spawn.transform.position.y, spawn.transform.position.z - expansion);
					s.transform.position = newPos;
					east.zBottom -= expansion;
					west.zBottom -= expansion;
				}
				if(s == north) { // north side  
					Debug.Log("north");
					Vector3 newPos = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z + expansion);
					s.transform.position = newPos;
					east.zTop += expansion;
					west.zTop += expansion;
				}
				if(s == west){ // west side
					Debug.Log("west");
					Vector3 newPos = new Vector3(spawn.transform.position.x - expansion, spawn.transform.position.y, spawn.transform.position.z);
					s.transform.position = newPos;
					south.xBottom -= expansion;
					north.xBottom -= expansion;

				}
				if (s == east) { // east side (motherfucker)
					Debug.Log("east");
					Vector3 newPos = new Vector3(spawn.transform.position.x + expansion, spawn.transform.position.y, spawn.transform.position.z);
					s.transform.position = newPos;
					south.xTop += expansion;
					north.xTop += expansion;
				}

			}
		}

	}


}
