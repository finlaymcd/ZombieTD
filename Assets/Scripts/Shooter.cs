using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public Projectile projectile;
	private float shootTime;
	private float t;
	private Zombie target;
	private Zombie[] zombies;
	private Vector3 currentPos;
	public double sightRange;
	public GameObject sight;
	private bool zombiesNear = false;
	private float searchTimer;
	public bool inBuilding;
	public Building occupiedBuilding;
	public int health;
	private Vector3 startPos;
	private Resource targetResource;
	private float moveSpeed;
	private bool moving;
	public Transform trans;
	bool gathering;
	bool movingToResource;
	bool movingFromResource;
	private int gatherSpeed;
	private int resourceHeld;
	private int resourceCapacity;
	private Base bas;
	private GameManager man;
	private float gatherTimer;
	private bool milling;
	private float xPos;
	private float zPos;
	private Vector3 newPos;
	private Transform actualPos;
	private bool shooting;
	private string name;
	public ScoutManager scoutMan;

	void Start () {
		scoutMan = GameObject.Find ("ScoutManager").GetComponent<ScoutManager>();
		man = FindObjectOfType<GameManager> ();
		shooting = false;
		actualPos = gameObject.GetComponentInChildren<MeshRenderer> ().transform;
		bas = FindObjectOfType<Base> ();
		resourceCapacity = 3;
		gatherSpeed = 1;
		moveSpeed = 0.5f;
		shootTime = 1;
		Invoke ("setName", 2);
		setLight ();


	}
	
	// Update is called once per frame
	void Update () {
		scanForZombies ();
		actualPos = gameObject.GetComponentInChildren<MeshRenderer> ().transform;
		if (milling) {
			Vector3 relativePos = newPos - transform.position;
			relativePos.y = 0;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			transform.rotation = rotation;

		}
		if(gathering == false && movingToResource == false && movingFromResource == false && inBuilding == false && shooting == false){
			millAbout ();
		}
		if (movingToResource) {
			if (moving) {
				moveToward ();
			}
		}

		if (gathering) {
			gatheringResource ();
		}

		if(movingFromResource){
			backToBase ();
		}

		if(target == null){

			scanForZombies ();




			currentPos = actualPos.position;
			float minDistance = Mathf.Infinity;
			zombies = FindObjectsOfType (typeof(Zombie)) as Zombie[];
			foreach(Zombie z in zombies){ //iterate through all zombies to find the closest
				if (z != null) { //make sure there are some zombies in scene
					Transform trans = z.gameObject.transform;
					float dist = Vector3.Distance (currentPos, trans.position);
					if (dist < minDistance) { //set the closest zombie
						minDistance = dist;
						target = z;

					}
				}
			}

		}

		if (t >= shootTime) { //if a few seconds have passed
			shoot ();
		}




		t += Time.deltaTime; //increment time

	}

	public string getName(){
		return name;
	}

	public void setName(){
		name = man.generateName ();
	}

	public void addResource(int i){
		Debug.Log ("i = " + i);
		resourceHeld += i;

	}

	public void shoot(){
		if (GameObject.Find("ZombiePrefab 1(Clone)")){ //if there is a zombie in scene
			if ((Vector3.Distance (actualPos.position, target.gameObject.transform.position)) <= sightRange) {
				shooting = true;
				if (inBuilding == false) {
					Vector3 relativePos = target.transform.position - actualPos.position;
					relativePos.y = 0;
					Quaternion rotation = Quaternion.LookRotation (relativePos);
					transform.rotation = rotation;
				}
				target.inSight ();
				Debug.Log ("shoot");
				(Instantiate (projectile)).setShooter (this.GetComponent<Shooter> (), target);//instantiate projectile, and immediately call the setShooter method on that projectile, passing in this game object, and the nearest zombie as target.
				t = 0; //reset timer to 0
				shootTime = 1; //set new random shoot time.
				scanForZombies ();
			} else {
				shooting = false;
			}
			}
	}

	public void setLight(){
		if (sightRange <= 1.0) {
			sight.transform.localScale = new Vector3 (20, 20, 1);
		} else if (sightRange <= 1.5) {
			sight.transform.localScale = new  Vector3(30, 30, 1);
		} else if (sightRange <= 2.0) {
			sight.transform.localScale = new  Vector3(40, 40, 1);
		} else if (sightRange <= 2.5) {
			sight.transform.localScale = new  Vector3(50, 50, 1);
		} else if (sightRange <= 3.0) {
			sight.transform.localScale = new  Vector3(60, 60, 1);
		} else if (sightRange <= 3.5) {
			sight.transform.localScale = new  Vector3(80, 80, 1);
		} else if (sightRange <= 4.0) {
			sight.transform.localScale = new  Vector3(90, 90, 1);
		} else {
			sight.transform.localScale = new  Vector3(100, 100, 1);
		}
	}

	public void scanForZombies(){ // if there are zombies near, checked every 1 second
		zombies = FindObjectsOfType (typeof(Zombie)) as Zombie[];
		foreach(Zombie z in zombies){
			if((Vector3.Distance(currentPos, z.gameObject.transform.position)) <= sightRange){
				interrupt ();
				z.inSight ();
				if (target != null) {
					if (target.model != null) {
						target = z;
					}
				}
			}
		}

	}

	public void interrupt(){
		gathering = false;
		movingFromResource = false;
		movingToResource = false;
		milling = false;
	}

	public void addHealth(int h){
		health += h;
	}

	public void removeHealth(int h){
		health -= h;
		if(health <= 0){
			Destroy (gameObject);
		}
	}

	public void setCurrentPos(){
		startPos = transform.position;
	}




	public void gatheringResource(){
		if (gatherTimer >= 1.0f) {
			if (resourceHeld < resourceCapacity && targetResource.amountContained >= 0) {
				targetResource.removeResource (gatherSpeed, this);
				gatherTimer = 0;
				//resourceHeld += resourceCapacity; 

			} else {
				gathering = false;
				movingFromResource = true;
				gatherTimer = 0;
			}
		}
		gatherTimer += Time.deltaTime;
	}




	public void moveToward(){

		if (moving == false) {
			transform.position = startPos;
			}

		moving = true;

		if (Vector3.Distance (transform.position, targetResource.transform.position) > 0.2f) { //checks how close the building is. If it's too close, it won't move, and starts attacking it instead (see else)
			float step = moveSpeed * Time.deltaTime; //move towards the closest buidling

		

			transform.position = Vector3.MoveTowards (transform.position, targetResource.transform.position, step);

		} 
		else {
			moving = false;
			movingToResource = false;
			gathering = true;
			movingFromResource = false;
		
		}
	}


	public void backToBase(){

		if (Vector3.Distance (transform.position, bas.transform.position) > 0.5f) { //checks how close the building is. If it's too close, it won't move, and starts attacking it instead (see else)
			float step = moveSpeed * Time.deltaTime; //move towards the closest buidling
			transform.position = Vector3.MoveTowards (transform.position, bas.transform.position, step);
		} else {
			man.addWood (resourceHeld);
			resourceHeld = 0;
			startPos = transform.position;
			movingFromResource = false;
			collectResource (targetResource);
		}
	}

	public void collectResource(Resource r){

		if (r != null) {
			targetResource = r;
			gathering = false;
			movingToResource = true;
			movingFromResource = false;
			moveToward ();
		}
	}


	public void millAbout(){

		if(milling == false){
			
			xPos = Random.Range(-4.0f, 4.0f);
			zPos = Random.Range(-4.0f, 4.0f);
			newPos = new Vector3(xPos, 11, zPos);
			milling = true;
			
		}
		else{
			
			float step = moveSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, newPos, step);
	
			if(Vector3.Distance(transform.position, newPos) < 0.1F){
				milling = false;
			}
		}
	}

	public void scout(){
		scoutMan.addScout (this);
	}

}