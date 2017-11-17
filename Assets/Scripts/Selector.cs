using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	private GameObject dragObject;
	private Vector3 castPos;
	public RaycastHit hit;
	private float clickTime;
	private bool selecting;
	private bool panning;
	private Vector3 touchDownPos;
	public Camera cam;
	public float yTopLimit;
	public float yBottomLimit;
	public float xTopLimit;
	public float xBottomLimit;
	private float mouseSensitivity;

	// Use this for initialization
	void Start () {
		clickTime = 0;
		mouseSensitivity = 0.03f;
		selecting = true;
		panning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			touchDownPos = Input.mousePosition;

		}
		if (Input.GetMouseButton (0)) {
			clickTime += Time.deltaTime;

			if (dragObject == null) {
				setDraggable ();
			}
			if (dragObject != null && dragObject.gameObject.tag == "Draggable" && clickTime > 0.4f) {
				drag ();
			}

			else if(dragObject != null && dragObject.gameObject.tag != "Draggable"){
				panning = true;
			}
		}
			

		if (Input.GetMouseButtonUp (0)) {
			finishDrag ();
			panning = false;
		}

		if(panning && dragObject.gameObject.tag != "draggable"){
			Vector3 dragDelta = (Input.mousePosition - touchDownPos);
			cam.gameObject.transform.Translate (dragDelta.x * mouseSensitivity * -1,dragDelta.y * mouseSensitivity * -1, 0);
			touchDownPos = Input.mousePosition;
			if(cam.gameObject.transform.localPosition.x > xTopLimit){
				cam.gameObject.transform.localPosition = new Vector3 (xTopLimit, cam.gameObject.transform.localPosition.y, cam.gameObject.transform.localPosition.z);
			}
			if(cam.gameObject.transform.localPosition.x < xBottomLimit){
				cam.gameObject.transform.localPosition = new Vector3 (xBottomLimit, cam.gameObject.transform.localPosition.y, cam.gameObject.transform.localPosition.z);
			}
			if(cam.gameObject.transform.localPosition.y > yTopLimit){
				cam.gameObject.transform.localPosition = new Vector3 (cam.gameObject.transform.localPosition.x, yTopLimit, cam.gameObject.transform.localPosition.z);
			}
			if(cam.gameObject.transform.localPosition.y < yBottomLimit){
				cam.gameObject.transform.localPosition = new Vector3 (cam.gameObject.transform.localPosition.x, yBottomLimit, cam.gameObject.transform.localPosition.z);
			}
		}


	}





	public void drag(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			castPos = new Vector3 (hit.point.x, 11.028f, hit.point.z);
			dragObject.transform.position = castPos;
		}
	}

	public void setDraggable(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			dragObject = hit.collider.gameObject;
			if (dragObject.GetComponent<Shooter> () != null) {
				Shooter shoot = dragObject.GetComponent<Shooter> ();
				shoot.setCurrentPos ();
				if (shoot.inBuilding = true  && shoot.occupiedBuilding != null) {
					shoot.occupiedBuilding.removeOccupant (shoot);
				}
			}



		}
	}



	public void finishDrag(){
		if (dragObject != null) {
			if (dragObject.GetComponent<Building> () != null) {
				PositionalRounding p = dragObject.GetComponent<PositionalRounding> ();
				p.rePosition ();
			}

			if (dragObject.GetComponent<Shooter> () != null) {
				Shooter shooter = dragObject.GetComponent<Shooter> ();
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
                    Debug.Log(hit.transform.gameObject.name);
					if (hit.collider.gameObject.GetComponent<Building> ()) {
						shooter.interrupt ();
						Building b = hit.collider.gameObject.GetComponent<Building> ();
						b.addOccupant (dragObject.GetComponent<Shooter> ());
					}
					if (hit.collider.gameObject.tag == "Resource") {
						shooter.interrupt ();
						Resource r = hit.collider.GetComponentInParent<Resource>();
						shooter.collectResource (r);
					}
					if(hit.collider.gameObject.tag == "ScoutUI"){
						shooter.scout ();
					}
				}
			}
		}
		dragObject = null;
		clickTime = 0;
	}


	public void increaseCameraBounds(string pos){
		if(pos == "n"){
			yTopLimit += 0.05f;
			xTopLimit += 0.05f;
		}
		if(pos == "s"){
			yBottomLimit -= 0.05f;
			xBottomLimit -= 0.05f;
		}
		if(pos == "e"){
			yBottomLimit -= 0.05f;
			xTopLimit += 0.05f;
		}
		if(pos == "w"){
			yTopLimit += 0.05f;
			xBottomLimit -= 0.05f;
		}
	}





}








