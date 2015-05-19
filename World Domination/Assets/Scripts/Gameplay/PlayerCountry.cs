using UnityEngine;
using System.Collections;

public class PlayerCountry : MonoBehaviour {

	Vector2 mouseCoord;
	RaycastHit hit;
    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponentInChildren<Camera> ();
        cam.enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		mouseCoord = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		mouseCoord = cam.ScreenToWorldPoint (mouseCoord);
		this.GetComponent<CountryMotor> ().Movement (mouseCoord);
        if (!cam.enabled)
            cam.enabled = true;
        cam.orthographicSize = 25 + (GetComponent<CountryMotor> ().population / 5);
	}
}
