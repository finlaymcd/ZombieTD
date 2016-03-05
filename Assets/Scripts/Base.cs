using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Base : Building {

	private float clickTime;
	private float lerpTime;
	private bool timing;
	public Button menu;
	private RectTransform r;
	private bool menuOut;
	private bool lerping;
	private Vector2 currentVector;
	private Vector2 targetVector;

	// Use this for initialization
	void Start () {
		lerping = false;
		r = menu.GetComponent<RectTransform> ();
		menuOut = false;
		clickTime = 0;
		maxHealth = 15;
		capacity = 5;
		health = maxHealth;
	}

	void Update(){
		Debug.Log (lerpTime);
		if (timing) {
			clickTime += Time.deltaTime;
		}
		if (lerping) {
			Vector2 size = Vector2.Lerp (currentVector, targetVector, lerpTime);
			r.sizeDelta = size;
			lerpTime += Time.deltaTime;
		}

		if (lerpTime >= 1.0f) {
			
			lerping = false;
			lerpTime = 0;
		}

	}

	public void OnMouseDown(){
		timing = true;


	}

	public void OnMouseUp(){
		Debug.Log ("mouse up");
		timing = false;
		if (clickTime < 0.3f){
			if (menuOut) {
				hideMenu ();
			} else {
				revealMenu ();
			}
		}
		clickTime = 0;
	}

	public void revealMenu(){
		Debug.Log ("reveal");
		targetVector = new Vector2 (70, r.sizeDelta.y);
		currentVector = new Vector2 (r.sizeDelta.x, r.sizeDelta.y);
		lerping = true;
		menuOut = true;
	}

	public void hideMenu(){
		currentVector = new Vector2 (r.sizeDelta.x, r.sizeDelta.y);
		targetVector = new Vector2 (2, r.sizeDelta.y);
		lerping = true;
		menuOut = false;
	}
}
