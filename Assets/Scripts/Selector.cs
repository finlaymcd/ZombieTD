using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	private PositionalRounding tower;
	private Vector3 castPos;
	public RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				print (hit.point);
				castPos = new Vector3 (hit.point.x, 11.0f, hit.point.z);
				if (hit.collider.gameObject.GetComponent<PositionalRounding> () != null) {
					tower = hit.collider.gameObject.GetComponent<PositionalRounding> ();
					//tower.rePosition (castPos);
					tower.transform.position = castPos;
				}

			}
		}
		if(Input.GetMouseButtonUp(0)){
			if(tower != null){
			tower.rePosition ();
			}
			tower = null;
		}
	}



}