using UnityEngine;
using System.Collections;

public class SpaceshipMotor : MonoBehaviour {

	public Vector3 curRot;
	Vector3 prevPos;
	public float speed;
	public float fuel;
	float acceleration = 0.1f;
	float maxSpeed = 50;
	int maxFuel = 15000;
	float turnSpeed = 30;
	float speedPerFuel = 50;
	int cargoSpace = 25;
	GameObject[] planets;
	float gravity = 0.25f;
	public float distance;

	// Use this for initialization
	void Start () {
		fuel = maxFuel;
		ScanForPlanets ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (speed > maxSpeed)
			speed = maxSpeed;
		if (speed < 2 && speed > -2 && Input.GetKeyDown (KeyCode.X))
			speed = 0;
		curRot = (transform.position - prevPos) / Time.deltaTime;
		prevPos = transform.position;
		GetComponent<Rigidbody> ().transform.position += transform.forward * speed * Time.deltaTime;
		if(speed > 0)
			fuel -= (speed / speedPerFuel);
		if (speed < 0)
			fuel -= (-speed / speedPerFuel);
		if (Application.loadedLevel != 0) {
			for (int i = 0; i < planets.Length; i++) {
				if (Vector3.Distance (planets [i].transform.position, transform.position) < planets [i].transform.localScale.x * 3) {
					distance = Mathf.Lerp (0, 1, (planets [i].transform.localScale.x * 3 - Vector3.Distance (planets [i].transform.position, transform.position)) / (planets [i].transform.localScale.x * 5));
					GetComponent<Rigidbody> ().transform.position += (planets [i].transform.position - transform.position) * (gravity * distance) * Time.deltaTime;
				}
			}
		}
	}

	public void CalculateEngineSpeed(int engineLevel){
		switch (engineLevel) {
		case 0:
			SetMaxSpeed(50);
			SetAcceleration(0.1f);
			break;
		case 1:
			SetMaxSpeed(75);
			SetAcceleration(0.25f);
			break;
		}
	}

	public void CalculateTurnSpeed(int wingLevel){
		switch (wingLevel) {
		case 0:
			SetTurnSpeed(30);
			break;
		case 1:
			SetTurnSpeed(45);
			break;
		}
	}

	public void Thrust(float value){
		if(value > 0 && speed < maxSpeed)
			speed += value;
		if (value < 0 && speed > -maxSpeed / 3)
			speed += value;
	}

	public void Rotate(Vector3 rotation){
//		transform.Rotate (rotation);
		Quaternion deltaRotation = Quaternion.Euler (rotation * turnSpeed * Time.deltaTime);
		GetComponent<Rigidbody> ().MoveRotation ((GetComponent<Rigidbody>().rotation * deltaRotation));
	}

	public void ScanForPlanets(){
		planets = GameObject.FindGameObjectsWithTag ("Planet");
	}

#region Get and Set
	public float GetMaxSpeed(){
		return maxSpeed;
	}

	public float GetGravity(){
		return gravity;
	}

	public void SetGravity(float value){
		gravity = value;
	}

	public void SetMaxSpeed(float value){
		maxSpeed = value;
	}
	
	public float GetSpeed(){
		return speed;
	}

	public float GetTurnSpeed(){
		return turnSpeed;
	}

	public void SetTurnSpeed(float value){
		turnSpeed = value;
	}
	
	public void SetSpeed(float value){
		speed = value;
	}

	public int GetMaxFuel(){
		return maxFuel;
	}

	public void SetMaxFuel(int value){
		maxFuel = value;
	}

	public float GetAcceleration(){
		return acceleration;
	}

	public void SetAcceleration(float value){
		acceleration = value;
	}

	public int GetCargoSpace(){
		return cargoSpace;
	}

	public void SetCargoSpace(int value){
		cargoSpace = value;
	}
#endregion
}
