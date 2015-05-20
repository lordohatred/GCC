using UnityEngine;
using System.Collections;

public class ShipMaster : MonoBehaviour {

    public GameObject player;

    private float acceleration = 0.2f;
    private float gravity = 0.1f;
    private int maxSpeed = 50;
    private int maxFuel = 15000;
    private int maxCargo = 30;
    private int turnSpeed = 30;
    private int fuelPerSpeed = 100;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}

    public float Acceleration {
        get { return acceleration; }
    }

    public float Gravity {
        get { return gravity; }
    }

    public int MaxSpeed {
        get { return maxSpeed; }
    }

    public int MaxFuel {
        get { return maxFuel; }
    }

    public int MaxCargo {
        get { return maxCargo; }
    }

    public int TurnSpeed {
        get { return turnSpeed; }
    }

    public int FuelPerSec {
        get { return fuelPerSpeed; }
    }
}