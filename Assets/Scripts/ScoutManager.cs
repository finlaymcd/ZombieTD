using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoutManager : MonoBehaviour {

	private List<Shooter> scouts = new List<Shooter>();
	public ScoutMenu scoutUI;
	private float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(scouts.Count >= 1){
		time += Time.deltaTime;
		}

	}

	public float generateTime(){
		return time;
	}

	public void addScout(Shooter s){
		scoutUI.addScoutUI (s);
		scouts.Add (s);
		MeshRenderer[] visible = s.gameObject.GetComponentsInChildren<MeshRenderer> ();
		foreach(MeshRenderer m in visible){
			m.enabled = false;
		}
	}

	public void returnScout(Shooter s, ScoutUIItem item, float startTime){
		float totalTime = time - startTime;
		reapReward (totalTime);
		bool destroy = false;
		foreach(Shooter shoot in scouts){
			if(shoot == s){
				s.returnFromScout ();
				destroy = true;
				MeshRenderer[] visible = s.gameObject.GetComponentsInChildren<MeshRenderer> ();
				foreach(MeshRenderer m in visible){
					m.enabled = true;
				}
			}
		}

		scouts.Remove (s);
		destroyUIitem (item);
		if (scouts.Count == 0) {
			time = 0;
		}
	}

	public void destroyUIitem(ScoutUIItem item){
		Destroy (item.gameObject);
	}

	public void reapReward(float timeOut){
		Debug.Log ("reap reward, time out: " + timeOut);
	}
}
