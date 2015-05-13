using UnityEngine;
using System.Collections;

public class PlayerCountry : MonoBehaviour {

	Vector2 mouseCoord;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		mouseCoord = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		mouseCoord = Camera.main.ScreenToWorldPoint (mouseCoord);
		this.GetComponent<CountryMotor> ().Movement (mouseCoord);
	}
}
