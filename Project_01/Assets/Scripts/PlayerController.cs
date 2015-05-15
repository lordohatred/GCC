using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector3 desiredRotation;
	float maxTurn = 15.0f, turnSpeed = 0.1f;
	bool onFoot = false;
	Vector2 movement;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!onFoot && name == "Player") {
			if (Input.GetKey (KeyCode.LeftShift)) {
				GetComponent<SpaceshipMotor> ().Thrust (0.25f);
			}
			if (Input.GetKey (KeyCode.LeftControl)) {
				GetComponent<SpaceshipMotor> ().Thrust (-0.25f);
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
	}

	public bool IsOnFoot(){
		return onFoot;
	}
}
