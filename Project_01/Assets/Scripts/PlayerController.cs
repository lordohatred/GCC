using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector3 desiredRotation;
	float maxTurn = 15.0f, turnSpeed = 0.1f;
	bool firstPerson = true;
	bool onFoot = false;
	Vector2 movement;

	// Use this for initialization
	void Start () {
		GameObject.Find ("3ps_Camera").GetComponent<Camera> ().enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			onFoot = !onFoot;
		}
		if (!onFoot && name == "Player") {
			GameObject.Find("Character_Camera").GetComponent<Camera>().enabled = false;
			if (Input.GetKeyDown (KeyCode.F1))
				firstPerson = !firstPerson;
			if (firstPerson) {
				GameObject.Find ("3ps_Camera").GetComponent<Camera> ().enabled = false;
			} else {
				GameObject.Find ("3ps_Camera").GetComponent<Camera> ().enabled = true;
			}
			if (Input.GetKey (KeyCode.LeftShift)) {
				GetComponent<SpaceshipMotor> ().Thrust (1);
			}
			if (Input.GetKey (KeyCode.LeftControl)) {
				GetComponent<SpaceshipMotor> ().Thrust (-1);
			}
			desiredRotation.z = -Input.GetAxis ("Roll") * maxTurn;
			desiredRotation.x = Input.GetAxis ("Pitch") * maxTurn;
			desiredRotation.y = Input.GetAxis ("Yaw") * (maxTurn / 5);
			GetComponent<SpaceshipMotor> ().Rotate (desiredRotation * turnSpeed);
		}
		if (name == "Player") {
			if (Input.GetKeyDown (KeyCode.B)) {
				GetComponentInChildren<Light_Color> ().SetColorRed ();
			}
			if (Input.GetKeyDown (KeyCode.N)) {
				GetComponentInChildren<Light_Color> ().SetColorBlue ();
			}
			if (Input.GetKeyDown (KeyCode.M)) {
				GetComponentInChildren<Light_Color> ().SetColorGreen ();
			}
		}
		if (onFoot && name == "Character") {
			GameObject.Find("Character_Camera").GetComponent<Camera>().enabled = true;
			GameObject.Find("3ps_Camera").GetComponent<Camera>().enabled = false;
			movement.x = Input.GetAxis("Roll");
			movement.y = Input.GetAxis("Pitch");
			GetComponent<OnFootMotor>().Movement(new Vector3(movement.x, 0, movement.y));
		}
		if (!onFoot && name == "Character") {
			transform.localPosition = new Vector3(0, 0.16f, 10.3f);
		}
	}

	public bool IsOnFoot(){
		return onFoot;
	}
}
