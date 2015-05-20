using UnityEngine;
using System.Collections;

public class SpaceshipMotor : MonoBehaviour {

    ShipMaster ship;

//UI and Gravity
	public float distance;
    public bool useGravity = false;
	public Vector3 curRot;
	Vector3 prevPos;
    GameObject[] planets;
    float gravity;

//Hull Levels
    private int cockpit = -1;
    private int wings = -1;
    private int engines = -1;
    private int cargo = 0;

//Current Speed and Fuel
	private float speed;
	private float fuel;

//Private MovementVariables
    private float acceleration;
    private int maxSpeed;
    private int maxFuel;
    private int maxCargo;
    private int turnSpeed;
    private int speedPerFuel;


	void Start () {
        ship = GameObject.Find("ShipMaster").GetComponent<ShipMaster>();
		fuel = maxFuel;
		ScanForPlanets ();
	}

    void OnLevelWasLoaded (int level) {
        if (level != 0) {
            Calculate ();
        }
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

	public void ScanForPlanets(){
		planets = GameObject.FindGameObjectsWithTag ("Planet");
	}

#region Calculations
    void Calculate () {
        CalculateMaxSpeed ();
        CalculateMaxFuel ();
        CalculateMaxCargo ();
        CalculateTurnSpeed ();
        CalculateAcceleration ();
        CalculateFuelPerSec ();
        CalculateGravity ();
    }

    void CalculateMaxSpeed () {
        maxSpeed = ship.MaxSpeed + (ship.MaxSpeed * EngineLevel) / 2;
    }

    void CalculateMaxFuel () {
        maxFuel = ship.MaxFuel + (ship.MaxFuel * CockpitLevel) / 2;
    }

    void CalculateMaxCargo () {
        maxCargo = ship.MaxCargo + (ship.MaxCargo * CargoLevel) / 2;
    }

    void CalculateTurnSpeed () {
        turnSpeed = ship.TurnSpeed + (ship.TurnSpeed * WingLevel) / 2;
    }

    void CalculateAcceleration () {
        acceleration = ship.Acceleration + (ship.Acceleration * EngineLevel) / 2;
    }

    void CalculateFuelPerSec () {
        speedPerFuel = ship.FuelPerSec + (ship.FuelPerSec * CockpitLevel) / 2;
    }

    void CalculateGravity () {
        gravity = ship.Gravity - (ship.Gravity * CockpitLevel) / 2;
    }
#endregion

#region Get and Set
    public float Gravity{
        get { return gravity; }
        set { gravity = value; }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public float Fuel {
        get { return fuel; }
        set { fuel = value; }
    }

    public int CockpitLevel {
        get { return cockpit; }
        set { cockpit = value; }
    }

    public int WingLevel {
        get { return wings; }
        set { wings = value; }
    }

    public int EngineLevel {
        get { return engines; }
        set { engines = value; }
    }

    public int CargoLevel {
        get { return cargo; }
        set { cargo = value; }
    }

    public int MaxSpeed {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    public int MaxFuel {
        get { return maxFuel; }
        set { maxFuel = value; }
    }

    public int TurnSpeed {
        get { return turnSpeed; }
        set { turnSpeed = value; }
    }

    public int SpeedPerFuel {
        get { return speedPerFuel; }
        set { speedPerFuel = value; }
    }

    public int MaxCargo {
        get { return maxCargo; }
        set { maxCargo = value; }
    }

    public float Acceleration {
        get { return acceleration; }
        set { acceleration = value; }
    }
#endregion
}
