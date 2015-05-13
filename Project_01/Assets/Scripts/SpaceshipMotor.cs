using UnityEngine;
using System.Collections;

public class SpaceshipMotor : MonoBehaviour {

	public float speed;
	public float fuel;
	float acceleration = 0.25f;
	float maxSpeed = 100;
	int maxFuel = 15000;

	// Use this for initialization
	void Start () {
		fuel = maxFuel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (speed > maxSpeed)
			speed = maxSpeed;
		if (speed < -maxSpeed / 3)
			speed = -maxSpeed / 3;
		if (speed > 0)
			fuel -= speed / 100;
		else
			fuel += speed / 100;
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	public void Thrust(float value){
		if(speed < maxSpeed && (value * acceleration) > 0)
			speed += value * acceleration;
		if ((value * acceleration) < 0)
			speed += value * acceleration;
	}

	public void Rotate(Vector3 rotation){
		if (speed > 15) {
			transform.Rotate(new Vector3((rotation.x / (speed / 20)), rotation.y / (speed / 20), rotation.z));
		}
		else
			transform.Rotate (rotation);
	}

	public float GetMaxSpeed(){
		return maxSpeed;
	}

	public void SetMaxSpeed(float value){
		maxSpeed = value;
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
}
