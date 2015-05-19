using UnityEngine;
using System.Collections;

public class SpaceshipMotor : MonoBehaviour {

	public float speed;
	public float distance;
    public bool useGravity = false;
	public Vector3 curRot;

	float acceleration = 0.1f;
	float maxSpeed = 50;
	float fuel;
	float turnSpeed = 30;
	float speedPerFuel = 100;
	float gravity = 0.10f;
	int maxFuel = 15000;
	int cargoSpace = 25;
	Vector3 prevPos;
	GameObject[] planets;


	void Start () {
		fuel = maxFuel;
		ScanForPlanets ();
	}
	
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
		if (useGravity) {
			for (int i = 0; i < planets.Length; i++) {
				if (Vector3.Distance (planets [i].transform.position, transform.position) < planets [i].transform.localScale.x * 2) {
					distance = Mathf.Lerp (0, 1, (planets [i].transform.localScale.x * 2 - Vector3.Distance (planets [i].transform.position, transform.position)) / (planets [i].transform.localScale.x * 3.5f));
					GetComponent<Rigidbody> ().transform.position += (planets [i].transform.position - transform.position) * (gravity * distance) * Time.deltaTime;
				}
			}
		}
    }

    public void Thrust (float value) {
        if (value > 0 && speed < maxSpeed)
            speed += value;
        if (value < 0 && speed > -maxSpeed / 3)
            speed += value;
    }

    public void Rotate (Vector3 rotation) {
        //		transform.Rotate (rotation);
        Quaternion deltaRotation = Quaternion.Euler (rotation * turnSpeed * Time.deltaTime);
        GetComponent<Rigidbody> ().MoveRotation (GetComponent<Rigidbody> ().rotation * deltaRotation);
    }

#region Calculations
    public void CalculateEngineSpeed(int engineLevel){
		switch (engineLevel) {
		case 0:
			MaxSpeed = 50;
			Acceleration = 0.1f;
			break;
		case 1:
			MaxSpeed =75;
			Acceleration = 0.25f;
			break;
		}
	}

	public void CalculateTurnSpeed(int wingLevel){
		switch (wingLevel) {
		case 0:
			TurnSpeed = 30;
			break;
		case 1:
			TurnSpeed = 45;
			break;
		}
    }
#endregion

	public void ScanForPlanets(){
		planets = GameObject.FindGameObjectsWithTag ("Planet");
	}

#region Get and Set

    public float MaxSpeed{
        get { return maxSpeed;  }
        set { maxSpeed = value; }
    }

    public float Gravity{
        get { return gravity; }
        set { gravity = value; }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public float TurnSpeed {
        get { return turnSpeed; }
        set { turnSpeed = value; }
    }

    public int MaxFuel {
        get { return maxFuel; }
        set { maxFuel = value; }
    }

    public float Acceleration {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int CargoSpace {
        get { return cargoSpace; }
        set { cargoSpace = value; }
    }

    public float Fuel {
        get { return fuel; }
        set { fuel = value; }
    }
#endregion
}
