using UnityEngine;
using System.Collections;

public class HUD_Interface : MonoBehaviour {
	
	GameObject[] planets;
	GameObject[] stations;
	public int waypointMenu = 0;
	public int systemMenu = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (name) {
		case "SpeedText":
			GetComponent<TextMesh>().text = "X = " + transform.rotation.eulerAngles.x.ToString("F1") + "\n" + 
				"Y = " + transform.rotation.eulerAngles.y.ToString("F1") + "\n" +
					"Z = " + transform.rotation.eulerAngles.z.ToString("F1");
			break;
		case "WaypointText":
			switch(waypointMenu){
			case 1:
				planets = GameObject.FindGameObjectsWithTag("Planet");
				GetComponent<TextMesh>().text = planets[0].name + "\n" + (planets[0].transform.position - transform.position) + "\n" +
					planets[1].name + "\n" + (planets[1].transform.position - transform.position) + "\n" +
					planets[2].name + "\n" + (planets[2].transform.position - transform.position) + "\n" +
					planets[3].name + "\n" + (planets[3].transform.position - transform.position);
				break;
			case 0:
				stations = GameObject.FindGameObjectsWithTag("SpaceStation");
				GetComponent<TextMesh>().text = stations[0].name + "\n" + (stations[0].transform.position - transform.position) + "\n" +
					stations[1].name + "\n" + (stations[1].transform.position - transform.position) + "\n" +
					stations[2].name + "\n" + (stations[2].transform.position - transform.position) + "\n" +
					stations[3].name + "\n" + (stations[3].transform.position - transform.position);
				break;
			case 2:
				GetComponent<TextMesh>().text = "No known ships in this \nsystem";
				break;
			}
			break;
		case "SystemText":
			switch(systemMenu){
			case 0:
				GetComponent<TextMesh>().text = "Fuel : " + GetComponentInParent<SpaceshipMotor>().fuel.ToString("F1") + "\n" + "Shields : " + "1200/1200" + "\n" +
					"Speed : " + GetComponentInParent<SpaceshipMotor>().speed.ToString("F1") + "\n"
						+ "X : " + GetComponentInParent<SpaceshipMotor>().curRot.x.ToString("F1") + "\n"
						+ "Y : " + GetComponentInParent<SpaceshipMotor>().curRot.y.ToString("F1") + "\n"
						+ "Z : " + GetComponentInParent<SpaceshipMotor>().curRot.z.ToString("F1");
				break;
			case 1:
				GetComponent<TextMesh>().text = GameObject.Find("Cargo").GetComponent<CargoScript>().GetCargo();
				break;
			case 2:
				GetComponent<TextMesh>().text = "All weapons are :\ndisabled.";
				break;
			case 3:
				GetComponent<TextMesh>().text = "Hull condition is at:\n100%";
				break;
			}
			break;
		}
	}
}