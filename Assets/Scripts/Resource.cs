using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {


	public int amountContained = 5;
	private string resourceType;
	public string position;
	public string leftNeighbour;
	public string rightNeighbour;
	public Resource left;
	public Resource right;
	private float currentGapLeft;
	private float currentGapRight;
	public Vector3 leftSpawn;
	public Vector3 rightSpawn;
	public GameObject treeTile;
	public bool onX;


	void Start(){
		currentGapLeft = 1.5f;
		currentGapRight = 1.5f;
	}

	void Update(){
		if(position == "s"){
			Debug.Log (rightSpawn);
		}
	}

	public void removeResource(int a, Shooter s){
		
		if (a > amountContained) {
			a = amountContained;
		}
		amountContained -= a;
		s.addResource (a);
		//return b;
		if(amountContained == 0){
			if(gameObject != null){
				Vector3 currentPos = gameObject.transform.position;
				if(position == "n"){
					Vector3 newPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z + 0.1f );
					gameObject.transform.position = newPos;
					amountContained = 5;
					setTileSpawnVertical ();
					left.increaseLength (position);
					right.increaseLength (position);
				}
				if (position == "w") {
					Vector3 newPos = new Vector3 (currentPos.x - 0.1f , currentPos.y, currentPos.z );
					gameObject.transform.position = newPos;
					amountContained = 5;
					setTileSpawnVertical ();
					left.increaseLength (position);
					right.increaseLength (position);
				}
				if(position == "e"){
					Vector3 newPos = new Vector3 (currentPos.x + 0.1f , currentPos.y, currentPos.z );
					gameObject.transform.position = newPos;
					amountContained = 5;
					setTileSpawnVertical ();
					left.increaseLength (position);
					right.increaseLength (position);
				}
				if(position == "s"){
					Vector3 newPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z - 0.1f );
					gameObject.transform.position = newPos;
					amountContained = 5;
					setTileSpawnVertical ();
					left.increaseLength (position);
					right.increaseLength (position);
				}
			}
		}

	}

	public void increaseLength(string movingWall){
		if(movingWall == leftNeighbour){
			currentGapLeft += 0.1f;
			if(currentGapLeft >= 1.86){
				GameObject tile = Instantiate (treeTile, (leftSpawn), Quaternion.identity) as GameObject;
				if(onX == false){
					Vector3 rot = new Vector3 (treeTile.transform.rotation.x, 90, treeTile.transform.rotation.z);
					tile.transform.eulerAngles = rot;
					tile.transform.SetParent (this.gameObject.transform);
					tile.transform.parent = this.gameObject.transform;
				}
				currentGapLeft = 0;
				setLeftTileSpawnHorizontal ();
			}
		}
		if(movingWall == rightNeighbour){
			currentGapRight += 0.1f;
			if(currentGapRight >= 1.86){
				GameObject tile = Instantiate (treeTile, (rightSpawn), Quaternion.identity) as GameObject;
				if(onX == false){
					Vector3 rot = new Vector3 (treeTile.transform.rotation.x, 90, treeTile.transform.rotation.z);
					tile.transform.eulerAngles = rot;
					tile.transform.SetParent (this.gameObject.transform);
				}
				currentGapRight = 0;
				setRightTileSpawnHorizontal ();

			}
		}

	}

	public void setTileSpawnVertical(){
		Debug.Log ("called");
		if (onX) {
			if (position == "s") {
				Debug.Log ("set");
				Vector3 hold = new Vector3 (rightSpawn.x, rightSpawn.y, rightSpawn.z - 0.1f);
				rightSpawn = hold;
				hold = new Vector3 (leftSpawn.x, leftSpawn.y, leftSpawn.z - 0.1f);
				leftSpawn = hold;
			}
			if (position == "n") {
				Debug.Log ("set");
				Vector3 hold = new Vector3 (rightSpawn.x, rightSpawn.y, rightSpawn.z + 0.1f);
				rightSpawn = hold;
				hold = new Vector3 (leftSpawn.x, leftSpawn.y, leftSpawn.z + 0.1f);
				leftSpawn = hold;
			}
		} else {
			if(position == "e"){
				Debug.Log ("set");
				Vector3 hold = new Vector3 (rightSpawn.x  - 0.1f, rightSpawn.y, rightSpawn.z);
				rightSpawn = hold;
				hold = new Vector3 (leftSpawn.x  + 0.1f, leftSpawn.y, leftSpawn.z);
				leftSpawn = hold;
			}
			if(position == "w"){
				Debug.Log ("set");
				Vector3 hold = new Vector3 (rightSpawn.x  + 0.1f, rightSpawn.y, rightSpawn.z);
				rightSpawn = hold;
				hold = new Vector3 (leftSpawn.x  - 0.1f, leftSpawn.y, leftSpawn.z);
				leftSpawn = hold;
			}
		}
	}





	public void setRightTileSpawnHorizontal(){
		if (onX) {
	
			if(position == "s"){
				Vector3 hold = new Vector3 (rightSpawn.x  + 1.86f, rightSpawn.y, rightSpawn.z);
				rightSpawn = hold;

			}

			if(position == "n"){
				Vector3 hold = new Vector3 (rightSpawn.x  - 1.86f, rightSpawn.y, rightSpawn.z);
				rightSpawn = hold;

			}
		} else {

			if(position == "e"){
				Vector3 hold = new Vector3 (rightSpawn.x , rightSpawn.y, rightSpawn.z + 1.86f);
				rightSpawn = hold;
		
			}
			if(position == "w"){
				Vector3 hold = new Vector3 (rightSpawn.x , rightSpawn.y, rightSpawn.z - 1.86f);
				rightSpawn = hold;

			}
		}
	}

	public void setLeftTileSpawnHorizontal(){

		if (onX) {

			if(position == "s"){
				Vector3 hold = new Vector3 (leftSpawn.x  - 1.86f, leftSpawn.y, leftSpawn.z);
				leftSpawn = hold;
				Debug.Log ("set");
			}

			if(position == "n"){
				Vector3 hold = new Vector3 (leftSpawn.x  + 1.86f, leftSpawn.y, leftSpawn.z);
				leftSpawn = hold;
	
			}
		} else {

			if(position == "e"){
				Vector3 hold = new Vector3 (leftSpawn.x  , leftSpawn.y, leftSpawn.z - 1.86f);
				leftSpawn = hold;
		
			}
			if(position == "w"){
				Vector3 hold = new Vector3 (leftSpawn.x  , leftSpawn.y, leftSpawn.z + 1.86f);
				leftSpawn = hold;
	
			}
		}
	}




}
