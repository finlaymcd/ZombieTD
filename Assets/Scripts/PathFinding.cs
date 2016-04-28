using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	


	public void setDestination(Vector3 pos){
		agent.destination = pos;
	}

	public void deactivatePathfinding(){
		agent.enabled = false;
	}

	public void activatePathFinding(){
		agent.enabled = true;
	}
}
