using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector3 desiredRotation;
	float maxTurn = 15.0f, turnSpeed = 0.1f;
	bool onFoot = false;
	Vector2 movement;
	float acceleration;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}

	void OnLevelWasLoaded(int level){
		if (level != 0) {
			transform.position = new Vector3 (4807, 446, -2970);
			this.enabled = true;
			GetComponent<SpaceshipMotor>().enabled = true;
			GameObject.Find ("Main Camera").GetComponent<MouseLook> ().enabled = true;
			GameObject.Find ("CameraHolder").GetComponent<MouseLook> ().enabled = true;
			GetComponent<SpaceshipMotor>().CalculateEngineSpeed(GameObject.Find("ShipMaster").GetComponent<ShipMaster>().engines);
			GetComponent<SpaceshipMotor>().CalculateTurnSpeed(GameObject.Find("ShipMaster").GetComponent<ShipMaster>().wings);
            GetComponent<SpaceshipMotor>().useGravity = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		acceleration = GetComponent<SpaceshipMotor> ().Acceleration;
		if (!onFoot && name == "Player") {
			if (Input.GetKey (KeyCode.LeftShift)) {
				GetComponent<SpaceshipMotor> ().Thrust (acceleration);
			}
			if (Input.GetKey (KeyCode.LeftControl)) {
				GetComponent<SpaceshipMotor> ().Thrust (-acceleration);
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
