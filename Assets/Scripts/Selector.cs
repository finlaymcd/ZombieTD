using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	private PositionalRounding tower;
	private Vector3 castPos;
	public RaycastHit hit;
	private float clickTime;

	// Use this for initialization
	void Start () {
		clickTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			clickTime += Time.deltaTime;
		}
		if ((clickTime > 0.18)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				castPos = new Vector3 (hit.point.x, 11.0f, hit.point.z);
				if (hit.collider.gameObject.GetComponent<PositionalRounding> () != null) {
					if(hit.collider.gameObject.GetComponent<Building>().canEdit){
					tower = hit.collider.gameObject.GetComponent<PositionalRounding> ();
					//tower.rePosition (castPos);
					tower.transform.position = castPos;
					}
				}

			
		}
	}
		if(Input.GetMouseButtonUp(0)){
			clickTime = 0;
			if(tower != null){
			tower.rePosition ();
			}
			tower = null;
		}
	}

}

