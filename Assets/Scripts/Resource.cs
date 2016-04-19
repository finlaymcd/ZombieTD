using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {


	public int amountContained = 5; // amount 
	private string resourceType; // currently not in use
	public string position; //north, east, south or west
	public string leftNeighbour;// the name of the resource to this resources left
	public string rightNeighbour;// the name of the resource to this resources right
	public Resource left; //the actual resource to the left
	public Resource right; //the actual resource to the right
	private float currentGapLeft; //When this reaches a certain size, a tile is placed
	private float currentGapRight; // ^^^^
	public Vector3 leftSpawn; // the position to spawn the tile on the left
	public Vector3 rightSpawn; //the position to spawn the tile on the right
	public GameObject treeTile; //spawned prefab
	public bool onX; //on the x axis or z axis


	void Start(){
		currentGapLeft = 1.0f;
		currentGapRight = 1.0f;
	}

	void Update(){
		if(position == "s"){
			Debug.Log (rightSpawn);
		}
	}

	//called by the shooter class, removes resource from the resource and gives it to the shooter
	public void removeResource(int a, Shooter s){
		
		if (a > amountContained) {
			a = amountContained; //so we don't take resource that isnt there
		}
		amountContained -= a;
		s.addResource (a); //give it back to the shooter
		//return b;
		if(amountContained == 0){ //if the resource is empty, it takes a step back and refills
			if(gameObject != null){
				Vector3 currentPos = gameObject.transform.position;
				if(position == "n"){
					Vector3 newPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z + 0.1f );
					gameObject.transform.position = newPos;
					amountContained = 5;
					setTileSpawnVertical (); // reset where the tile spawns
					left.increaseLength (position);
					right.increaseLength (position); //tell the resources on the left and right of this resource they may need to spawn a tile to fill the gap
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
			currentGapLeft += 0.1f; //logging the gap between this resource and it's neighbour that just moved.
			if(currentGapLeft >= 1.86){ // if the gap is the width of a tile, instantiate a tile there.
				GameObject tile = Instantiate (treeTile, (leftSpawn), Quaternion.identity) as GameObject;
				if(onX == false){
					Vector3 rot = new Vector3 (treeTile.transform.rotation.x, 90, treeTile.transform.rotation.z);
					tile.transform.eulerAngles = rot; //if it's on the z axis, rotate it
				}
				tile.transform.SetParent (this.gameObject.transform, true); //parent it so it moves with the rest of the bush.


				currentGapLeft = 0;
				setLeftTileSpawnHorizontal ();
			}
		}
		if(movingWall == rightNeighbour){ // same as above but for the other side
			currentGapRight += 0.1f;
			if(currentGapRight >= 1.86){
				GameObject tile = Instantiate (treeTile, (rightSpawn), Quaternion.identity) as GameObject;
				if(onX == false){
					Vector3 rot = new Vector3 (treeTile.transform.rotation.x, 90, treeTile.transform.rotation.z);
					tile.transform.eulerAngles = rot;
				}
				tile.transform.SetParent (this.gameObject.transform, true);


				currentGapRight = 0;
				setRightTileSpawnHorizontal ();

			}
		}

	}

	public void setTileSpawnVertical(){ // The below method changes the spawn point of the tile horizontally to the rest of the bush. This takes in to account when the resource is gathered and pushed back vertically
		Debug.Log ("called");
		if (onX) { //The right spawn and left spawn values are made public and set in editor. They are then tweaked as the game goes on through the code.
			if (position == "s") {
				Debug.Log ("set");
				Vector3 hold = new Vector3 (rightSpawn.x, rightSpawn.y, rightSpawn.z - 0.1f); //o.1, becuase that is how much it is pushed back
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
				Vector3 hold = new Vector3 (rightSpawn.x  + 0.1f, rightSpawn.y, rightSpawn.z);
				rightSpawn = hold;
				hold = new Vector3 (leftSpawn.x  + 0.1f, leftSpawn.y, leftSpawn.z);
				leftSpawn = hold;
			}
			if(position == "w"){
				Debug.Log ("set");
				Vector3 hold = new Vector3 (rightSpawn.x  - 0.1f, rightSpawn.y, rightSpawn.z);
				rightSpawn = hold;
				hold = new Vector3 (leftSpawn.x  - 0.1f, leftSpawn.y, leftSpawn.z);
				leftSpawn = hold;
			}
		}
	}





	public void setRightTileSpawnHorizontal(){ //every time a tile is spawned the spawn point needs to move out.
		if (onX) { //In total there are 8 potential spawn points that need to constantly change with the movement of the boundaries.
	
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
