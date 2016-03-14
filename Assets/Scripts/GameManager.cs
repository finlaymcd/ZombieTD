using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	private int wood;
	private int survivors;
	public Text woodText;
	public Spawner s1;
	public Spawner s2;
	public Spawner s3;
	public Spawner s4;
	public Spawner[] spawners;

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
				if(spawn.onXaxis == true && spawn.transform.position.x < 0){ //south side
					Vector3 newPos = new Vector3(spawn.transform.position.x - expansion, spawn.transform.position.z, spawn.transform.position.y);
					s.transform.position = newPos;
				}
				if(spawn.onXaxis == true && spawn.transform.position.x > 0){ // north side
					Vector3 newPos = new Vector3(spawn.transform.position.x + expansion, spawn.transform.position.z, spawn.transform.position.y);
					s.transform.position = newPos;
				}
				if(spawn.onXaxis == false && spawn.transform.position.z < 0){ // west side
					Vector3 newPos = new Vector3(spawn.transform.position.x, spawn.transform.position.z - expansion, spawn.transform.position.y);
					s.transform.position = newPos;
				}
				if (spawn.onXaxis == false && spawn.transform.position.z > 0) { // east side (motherfucker)
					Vector3 newPos = new Vector3(spawn.transform.position.x, spawn.transform.position.z + expansion, spawn.transform.position.y);
					s.transform.position = newPos;
				}
			}
		}

	}


}
