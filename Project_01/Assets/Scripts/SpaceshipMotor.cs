using UnityEngine;
using System.Collections;

public class SpaceshipMotor : MonoBehaviour {

	public Vector3 curRot;
	Vector3 prevPos;
	public float speed;
	public float fuel;
	float acceleration = 0.25f;
	float maxSpeed = 50;
	int maxFuel = 15000;
	float turnSpeed = 30;
	float speedPerFuel = 100;
	int cargoSpace = 50;

	// Use this for initialization
	void Start () {
		fuel = maxFuel;
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
		fuel -= speed / speedPerFuel;
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

#region Get and Set
	public float GetMaxSpeed(){
		return maxSpeed;
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
