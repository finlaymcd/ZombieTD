using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Base : Building {

	private float clickTime;
	private float lerpTime1;
	private bool timing1;
	public Button menu;
	public Button scoutMenu;
	private RectTransform r;
	private RectTransform scoutRect;
	private bool menuOut;
	private bool lerping1;
	private bool lerping2;
	private Vector2 currentSizeVector;
	private Vector2 targetSizeVector;
	public SecondLerp scout;
	public SecondLerp build;

	// Use this for initialization
	void Start () {
		height = 12.0f;
		lerping1 = false;
		r = menu.GetComponent<RectTransform> ();
		scoutRect = scoutMenu.GetComponent<RectTransform> ();
		menuOut = false;
		clickTime = 0;
		maxHealth = 15;
		capacity = 5;
		health = maxHealth;
		PositionalRounding p = gameObject.GetComponent<PositionalRounding> ();
		p.rePosition ();
	}

	void Update(){
		/*
		if (timing1) {
			clickTime += Time.deltaTime;
		}
		if (lerping1) {
			Vector2 size = Vector2.Lerp (currentSizeVector, targetSizeVector, lerpTime1);
			r.sizeDelta = size;
			scoutRect.sizeDelta = size;
			lerpTime1 += Time.deltaTime * 2;
		}

		if (lerpTime1 >= 1.0f) {
			
			lerping1 = false;
			lerpTime1 = 0;
			lerping2 = true;
		}
*/
	}

	public void OnMouseDown(){
		


	}

	public void OnMouseUp(){
		
		if (menuOut) {
			hideMenu ();

		} else {
			revealMenu ();
		}
	
	}

	public void revealMenu(){
		menuOut = true;
		build.startLerp ();
		scout.startLerp ();
	}

	public void hideMenu(){
		menuOut = false;
		build.fall ();
		scout.fall ();
	}
}
