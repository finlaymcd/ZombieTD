using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	private int wood;
	private int survivors;
	public Text woodText;



	void Start(){
		wood = 10;
		setWoodText();
	}

	public int gotWood(){
		return wood;
	}

	public void addWood(int w){
		wood += w;
		setWoodText();
	}

	public void removeWood(int w){

		wood = wood - w;

		setWoodText();
	}

	public void setWoodText(){
		woodText.text = "wood: " + wood;
	}


}
