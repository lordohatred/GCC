using UnityEngine;
using System.Collections;

public class Namer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = GetComponentInParent<CountryMotor> ().name;
		GetComponent<TextMesh> ().fontSize = 30 + (GetComponentInParent<CountryMotor> ().GetPopulation() / 10);
		GetComponent<TextMesh> ().color = Color.white;
	}

	void Update(){
		if (GetComponentInParent<CountryMotor> ().isPlayer == true && GameObject.Find("Handler").GetComponent<Handler>().GetPlayerName() != null) {
			ChangeName();
		}
	}

	void ChangeName(){
		if(GameObject.Find("Handler").GetComponent<Handler>().GetPlayerName() != null)
			GetComponent<TextMesh> ().text = GameObject.Find("Handler").GetComponent<Handler>().GetPlayerName();
	}
}
