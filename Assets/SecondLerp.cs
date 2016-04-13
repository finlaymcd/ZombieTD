using UnityEngine;
using System.Collections;

public class SecondLerp : MonoBehaviour {

	private float t;
	private bool opening;
	private bool expanding;
	private bool closing;
	private bool shrinking;
	private RectTransform r;
	public float HiddenSizeX;
	public float HiddenSizeY;
	public float HiddenPosX;
	public float HiddenPosY;
	public float OpenSizeX;
	public float OpenSizeY;
	public float OpenPosX;
	public float OpenPosY;
	private Vector2 hiddenSize;
	private Vector2 openSize;
	private Vector2 hiddenPos;
	private Vector2 openPos;
	private float lerpTime;


	void Start(){
		hiddenSize = new Vector2 (HiddenSizeX, HiddenSizeY);
		openSize = new Vector2 (OpenSizeX, OpenSizeY);
		hiddenPos = new Vector2 (HiddenPosX, HiddenPosY);
		openPos = new Vector2 (OpenPosX, OpenPosY);
		r = gameObject.GetComponent<RectTransform> ();

	}

	// Update is called once per frame
	void Update () {
		if(opening){
			Vector2 size = Vector2.Lerp (hiddenSize, openSize, lerpTime);
			r.sizeDelta = size;
			lerpTime += Time.deltaTime * 2.0f;
			if(lerpTime > 1){
				rise ();
			}

		}
		if(expanding){
			Vector2 pos = Vector2.Lerp (hiddenPos, openPos, lerpTime);
			r.anchoredPosition = pos;
			lerpTime += Time.deltaTime * 2.0f;
		}
		if(shrinking){
			Vector2 pos = Vector2.Lerp (openPos, hiddenPos, lerpTime);
			r.anchoredPosition = pos;
			lerpTime += Time.deltaTime * 2.0f;
			if(lerpTime > 1){
				closeMenu ();
			}
		}
		if(closing){
			Vector2 size = Vector2.Lerp (openSize, hiddenSize, lerpTime);
			r.sizeDelta = size;
			lerpTime += Time.deltaTime * 2.0f;
		}
	}

	public void startLerp(){
		closing = false;
		expanding = false;
		shrinking = false;
		opening = true;
		lerpTime = 0;
	}

	public void closeMenu(){
		
		expanding = false;
		opening = false;
		shrinking = false;
		closing = true;
		lerpTime = 0;
	}

	public void rise(){
		opening = false;
		closing = false;
		shrinking = false;
		expanding = true;
		lerpTime = 0;
	}
	public void fall(){
		shrinking = true;
		opening = false;
		closing = false;
		expanding = false;
		lerpTime = 0;
	}
}
