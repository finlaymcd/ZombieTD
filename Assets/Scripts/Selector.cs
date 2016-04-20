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
	public float northLimit;
	public float southLimit;
	public float eastLimit;
	public float westLimit;
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
			Debug.Log (cam.gameObject.transform.localPosition);
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


}










				/**

			if (dragObject != null) {
				dragObject.transform.position = castPos;
			}
		}
		if ((clickTime > 0.05)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				castPos = new Vector3 (hit.point.x, 11.0f, hit.point.z);
				if (hit.collider.gameObject.GetComponent<PositionalRounding> () != null) {
					if(hit.collider.gameObject.GetComponent<Building>().canEdit){
				
						dragObject = hit.collider.gameObject;
					}
				}

				else if (hit.collider.gameObject.GetComponent<Shooter> () != null) {
					dragObject = hit.collider.gameObject;
				}
			}
	}
		if(Input.GetMouseButtonUp(0)){
			clickTime = 0;
			if(dragObject != null && dragObject.GetComponent<PositionalRounding> () != null){
				PositionalRounding d = dragObject.GetComponent<PositionalRounding>();
				d.rePosition ();
			}
			if (dragObject.GetComponent<Shooter> () != null) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.GetComponent<Building> ()) {
						Building b = hit.collider.gameObject.GetComponent<Building> ();
						b.addOccupant (dragObject.GetComponent<Shooter>());
					}
				}
			}
			dragObject = null;
			**/

