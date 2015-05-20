using UnityEngine;
using System.Collections;

public class ShipSelectionScript : MonoBehaviour {

	bool isSelected = false;
	bool showCockpits = false;
	bool showWings = false;
	bool showEngines = false;
	ShipMaster ship;
    SpaceshipMotor motor;
    PlayerController player;

	// Use this for initialization
	void Start () {
		ship = GameObject.Find ("ShipMaster").GetComponent<ShipMaster> ();
        motor = GameObject.Find ("Player").GetComponent<SpaceshipMotor> ();
        player = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (name) {
		case "CockpitSelection":
			if(isSelected){
				showCockpits = true;
			}
			break;
		case "EngineSelection":
			if(isSelected){
				showEngines = true;
			}
			break;
		case "WingsSelection":
			if(isSelected){
				showWings = true;
			}
			break;
		}
	}

	public void ToggleSelection(){
		isSelected = !isSelected;
	}

	void ShowCockpits(int windowID){
		if (GUI.Button (new Rect (25, 50, 200, 100), "Small Cockpit")) {
			GameObject.Find("Modular_Cockpit_02").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Cockpit_02").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Stick_02").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Box001_MeshPart0").GetComponent<Renderer>().enabled = false;
			GameObject.Find("Box001_MeshPart1").GetComponent<Renderer>().enabled = false;
			GameObject.Find("Cockpit_03").GetComponent<Renderer>().enabled = false;
			GameObject.Find("Stick_03").GetComponent<Renderer>().enabled = false;
			this.GetComponent<Renderer>().enabled = false;
			GameObject.Find("CameraHolder").transform.localPosition = new Vector3(-0.04980907f, 1.707994f, 13.44492f);
			GameObject.Find("CockpitLight_1").GetComponent<Light>().enabled = true;
			GameObject.Find("CockpitLight_2").GetComponent<Light>().enabled = true;
			GameObject.Find("CockpitLight_3").GetComponent<Light>().enabled = false;
			GameObject.Find("CockpitLight_4").GetComponent<Light>().enabled = false;
			isSelected = false;
			showCockpits = false;
			motor.CockpitLevel = 0;
		}
		if (GUI.Button (new Rect (250, 50, 200, 100), "Medium Cockpit")) {
			GameObject.Find("Box001_MeshPart0").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Box001_MeshPart1").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Cockpit_03").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Stick_03").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Modular_Cockpit_02").GetComponent<Renderer>().enabled = false;
			GameObject.Find("Cockpit_02").GetComponent<Renderer>().enabled = false;
			GameObject.Find("Stick_02").GetComponent<Renderer>().enabled = false;
			this.GetComponent<Renderer>().enabled = false;
			GameObject.Find("CameraHolder").transform.localPosition = new Vector3(-0.05f, 1.981f, 18.766f);
			GameObject.Find("CockpitLight_1").GetComponent<Light>().enabled = false;
			GameObject.Find("CockpitLight_2").GetComponent<Light>().enabled = false;
			GameObject.Find("CockpitLight_3").GetComponent<Light>().enabled = true;
			GameObject.Find("CockpitLight_4").GetComponent<Light>().enabled = true;
			isSelected = false;
			showCockpits = false;
			motor.CockpitLevel = 1;
		}
		if (GUI.Button (new Rect (25, 300, 400, 100), "Close Window")) {
			isSelected = false;
			showCockpits = false;
		}
	}
	
	void ShowWings(int windowID){
		if (GUI.Button (new Rect (25, 50, 200, 100), "Small Wings")) {
			GameObject.Find("Modular_Wings_02").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Modular_Wings_01").GetComponent<Renderer>().enabled = false;
			this.GetComponent<Renderer>().enabled = false;
			isSelected = false;
			showWings = false;
			motor.WingLevel = 0;
		}
		if (GUI.Button (new Rect (250, 50, 200, 100), "Medium Wings")) {
			GameObject.Find("Modular_Wings_01").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Modular_Wings_02").GetComponent<Renderer>().enabled = false;
			this.GetComponent<Renderer>().enabled = false;
			isSelected = false;
			showWings = false;
			motor.WingLevel = 1;
		}
		if (GUI.Button (new Rect (25, 300, 400, 100), "Close Window")) {
			isSelected = false;
			showWings = false;
		}
	}
	
	void ShowEngines(int windowID){
		if (GUI.Button (new Rect (25, 50, 200, 100), "Small Engines")) {
			GameObject.Find("Modular_Engines_01").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Modular_Engines_02").GetComponent<Renderer>().enabled = false;
			this.GetComponent<Renderer>().enabled = false;
			isSelected = false;
			showEngines = false;
			motor.EngineLevel = 0;
		}
		if (GUI.Button (new Rect (250, 50, 200, 100), "Medium Engines")) {
			GameObject.Find("Modular_Engines_02").GetComponent<Renderer>().enabled = true;
			GameObject.Find("Modular_Engines_01").GetComponent<Renderer>().enabled = false;
			this.GetComponent<Renderer>().enabled = false;
			isSelected = false;
			showEngines = false;
            motor.EngineLevel = 1;
		}
		if (GUI.Button (new Rect (25, 300, 400, 100), "Close Window")) {
			isSelected = false;
			showEngines = false;
		}
	}

	void OnGUI(){
		if(showCockpits)
			GUI.Window (0, new Rect (75, 75, Screen.width / 4, Screen.height / 2), ShowCockpits, "Cockpits");
		if(showWings)
			GUI.Window (0, new Rect (75, 75, Screen.width / 4, Screen.height / 2), ShowWings, "Wings");
		if(showEngines)
			GUI.Window (0, new Rect (75, 75, Screen.width / 4, Screen.height / 2), ShowEngines, "Engines");
	}
}
